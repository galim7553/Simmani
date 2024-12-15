using System;
using System.Collections;
using System.Collections.Generic;
using GamePlay.Hubs.Equipments;
using UnityEngine;

namespace GamePlay.Modules
{
    public class EquipperModel : ModuleModelBase<IEquipperConfig>, IEquipperModel
    {
        // ----- Config ----- //
        HashSet<EquipSlot> _equipSlots;
        // ----- Config ----- //


        Dictionary<EquipSlot, IEquipmentModel> _equipmentModelMap = new Dictionary<EquipSlot, IEquipmentModel>();
        public IReadOnlyDictionary<EquipSlot, IEquipmentModel> EquipmentModelMap => _equipmentModelMap;

        

        public event Action<EquipSlot, IEquipmentModel> OnEquipped;
        public event Action<EquipSlot, IEquipmentModel> OnUnequipped;

        public EquipperModel(IEquipperConfig config) : base(config)
        {
            ResetEquipSlots();
        }

        public void ResetEquipSlots() => _equipSlots = new HashSet<EquipSlot>(Config.EquipSlots);

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
