using System;
using System.Collections;
using System.Collections.Generic;
using GamePlay.Hubs.Equipments;
using UnityEngine;

namespace GamePlay.Modules
{
    public interface IEquipperModel
    {
        IEquipperConfig Config { get; }

        event Action<EquipSlot, IEquipmentModel> OnEquipped;
        event Action<EquipSlot, IEquipmentModel> OnUnequipped;

        IReadOnlyDictionary<EquipSlot, IEquipmentModel> EquipmentModelMap { get; }
        bool TryEquip(IEquipmentModel model);
        void Unequip(EquipSlot slot);
    }
}


