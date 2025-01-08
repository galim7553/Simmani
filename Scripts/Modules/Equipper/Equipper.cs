using System.Collections.Generic;
using GamePlay.Factories;
using GamePlay.Hubs.Equipments;
using UnityEngine;

namespace GamePlay.Modules
{
    /// <summary>
    /// ��� ������ ������ ó���ϴ� Ŭ����.
    /// </summary>
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


        /// <summary>
        /// ���� ���԰� ��(HumanBodyBones)�� �����մϴ�.
        /// </summary>
        void MapEquipSlots()
        {
            foreach(var slot in _model.Config.EquipSlots)
            {
                if(EquipperUtil.TryGetHumanBodyBone(slot, out var bone))
                    _equipSlotMap[slot] = _animator.GetBoneTransform(bone);
            }
        }
        

        // �𵨿� �ִ� �� ��� Equip ó��
        public void Initialize()
        {
            foreach(var kvp in _model.EquipmentModelMap)
                Equip(kvp.Key, kvp.Value);
        }

        /// <summary>
        /// ��� ������ �����մϴ�.
        /// </summary>
        public void Equip(EquipSlot slot, IEquipmentModel model)
        {
            if (_equipSlotMap.TryGetValue(slot, out var parent) == false)
            {
                Debug.LogError($"���� ������ ���� ��ġ�� ã�� ���߽��ϴ�. {slot}");
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

        /// <summary>
        /// ��� ������ �����մϴ�.
        /// </summary>
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


        /// <summary>
        /// ��� ��� �����մϴ�.
        /// </summary>
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
            // �𵨿� �ִ� �� ��� Unequip ó��
            UnequipAll();

            _model.OnEquipped -= Equip;
            _model.OnUnequipped -= Unequip;
        }
    }
}

