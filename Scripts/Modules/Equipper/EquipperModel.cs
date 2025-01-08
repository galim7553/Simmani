using System;
using System.Collections.Generic;
using GamePlay.Hubs.Equipments;
using UnityEngine;

namespace GamePlay.Modules
{
    /// <summary>
    /// ��� ���� �����͸� �����ϴ� �⺻ ���� Ŭ����.
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
        /// ���� ������ �ʱ�ȭ�մϴ�.
        /// </summary>
        public void ResetEquipSlots() => _equipSlots = new HashSet<EquipSlot>(Config.EquipSlots);

        /// <summary>
        /// ��� �����մϴ�.
        /// </summary>
        public bool TryEquip(IEquipmentModel model)
        {
            if(_equipSlots.Contains(model.Config.EquipSlot) == false)
            {
                Debug.Log($"ĳ���Ϳ� {model.Config.EquipSlot} ���� ������ ���� {model.Config.Key} ��� ������ �� �����ϴ�.");
                return false;
            }

            Unequip(model.Config.EquipSlot);

            _equipmentModelMap[model.Config.EquipSlot] = model;
            model.SetHasEquipped(true);
            OnEquipped?.Invoke(model.Config.EquipSlot, model);
            return true;
        }

        /// <summary>
        /// Ư�� ������ ��� �����մϴ�.
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
