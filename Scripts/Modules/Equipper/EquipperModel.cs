using System;
using System.Collections.Generic;
using GamePlay.Hubs.Equipments;
using UnityEngine;

namespace GamePlay.Modules
{
    /// <summary>
    /// 장비 장착 데이터를 관리하는 기본 구현 클래스.
    /// </summary>
    public class EquipperModel : ModuleModelBase<IEquipperConfig>, IEquipperModel
    {
        HashSet<EquipSlot> _equipSlots;
        Dictionary<EquipSlot, IEquipmentModel> _equipmentModelMap = new Dictionary<EquipSlot, IEquipmentModel>();
        public IReadOnlyDictionary<EquipSlot, IEquipmentModel> EquipmentModelMap => _equipmentModelMap;

        
        public event Action<EquipSlot, IEquipmentModel> OnEquipped;
        public event Action<EquipSlot, IEquipmentModel> OnUnequipped;

        public EquipperModel(IEquipperConfig config) : base(config)
        {
            ResetEquipSlots();
        }

        /// <summary>
        /// 장착 슬롯을 초기화합니다.
        /// </summary>
        public void ResetEquipSlots() => _equipSlots = new HashSet<EquipSlot>(Config.EquipSlots);

        /// <summary>
        /// 장비를 장착합니다.
        /// </summary>
        public bool TryEquip(IEquipmentModel model)
        {
            if(_equipSlots.Contains(model.Config.EquipSlot) == false)
            {
                Debug.Log($"캐릭터에 {model.Config.EquipSlot} 장착 슬롯이 없어 {model.Config.Key} 장비를 장착할 수 없습니다.");
                return false;
            }

            Unequip(model.Config.EquipSlot);

            _equipmentModelMap[model.Config.EquipSlot] = model;
            model.SetHasEquipped(true);
            OnEquipped?.Invoke(model.Config.EquipSlot, model);
            return true;
        }

        /// <summary>
        /// 특정 슬롯의 장비를 해제합니다.
        /// </summary>
        public void Unequip(EquipSlot slot)
        {
            if (_equipmentModelMap.ContainsKey(slot))
            {
                IEquipmentModel equipmentModel = _equipmentModelMap[slot];
                _equipmentModelMap.Remove(slot);
                equipmentModel.SetHasEquipped(false);
                OnUnequipped?.Invoke(slot, equipmentModel);
            }
        }
    }
}
