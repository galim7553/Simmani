using System;
using System.Collections;
using System.Collections.Generic;
using GamePlay.Factories;
using GamePlay.Hubs.Equipments;
using UnityEngine;

namespace GamePlay.Modules
{
    public class Equipper : ModuleBase, IEquipper
    {
        IEquipperModel _model;
        EquipmentFactory _factory;
        Animator _animator;

        Dictionary<EquipSlot, Transform> _equipSlotMap = new Dictionary<EquipSlot, Transform>();

        Dictionary<EquipSlot, IEquipment> _equipmentMap = new Dictionary<EquipSlot, IEquipment>();

        List<float> _defaultLayerWeights = new List<float>();

        public EquipmentCache Cache { get; private set; } = new EquipmentCache();

        public Equipper(IEquipperModel model, EquipmentFactory factory, Animator animator)
        {
            _model = model;
            _factory = factory;
            _animator = animator;
            for(int i = 0; i < _animator.layerCount; i++)
                _defaultLayerWeights.Add(_animator.GetLayerWeight(i));

            _model.OnEquipped += Equip;
            _model.OnUnequipped += Unequip;
            MapEquipSlots();
        }


        void MapEquipSlots()
        {
            foreach(var slot in _model.Config.EquipSlots)
            {
                if(EquipperUtil.TryGetHumanBodyBone(slot, out var bone))
                    _equipSlotMap[slot] = _animator.GetBoneTransform(bone);
            }
        }
        

        // 모델에 있는 것 모두 Equip 처리
        public void Initialize()
        {
            foreach(var kvp in _model.EquipmentModelMap)
                Equip(kvp.Key, kvp.Value);
        }

        public void Equip(EquipSlot slot, IEquipmentModel model)
        {
            if (_equipSlotMap.TryGetValue(slot, out var parent) == false)
            {
                Debug.LogError($"장착 슬롯의 실제 위치를 찾지 못했습니다. {slot}");
                return;
            }

            IEquipment equipment = _factory.CreateEquipment(model);
            equipment.Equip(parent);
            _equipmentMap[slot] = equipment;

            AnimatorLayerInfo layerInfo = model.Config.AnimatorLayerInfo;
            if (layerInfo != null)
                _animator.SetLayerWeight(layerInfo.TargetLayerIndex, layerInfo.Weight);

            Cache.AddEquipment(equipment);
        }
        public void Unequip(EquipSlot slot, IEquipmentModel model)
        {
            if (_equipmentMap.ContainsKey(slot) == true)
            {
                AnimatorLayerInfo layerInfo = model.Config.AnimatorLayerInfo;
                if (layerInfo != null)
                    _animator.SetLayerWeight(layerInfo.TargetLayerIndex, _defaultLayerWeights[layerInfo.TargetLayerIndex]);

                Cache.RemoveEquipment(_equipmentMap[slot]);

                _equipmentMap[slot].Unequip();
                _equipmentMap.Remove(slot);
            }
        }

        void UnequipAll()
        {
            foreach(var equipment in _equipmentMap.Values)
            {
                Cache.RemoveEquipment(equipment);
                equipment.Unequip();
            }
            _equipmentMap.Clear();
            for(int i = 0; i < _defaultLayerWeights.Count; i++)
                _animator.SetLayerWeight(i, _defaultLayerWeights[i]);
        }

        public override void Clear()
        {
            // 모델에 있는 것 모두 Unequip 처리
            UnequipAll();

            _model.OnEquipped -= Equip;
            _model.OnUnequipped -= Unequip;
        }
    }
}

