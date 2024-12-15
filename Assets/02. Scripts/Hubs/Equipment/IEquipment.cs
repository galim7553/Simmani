using System.Collections;
using System.Collections.Generic;
using GamePlay.Modules;
using UnityEngine;

namespace GamePlay.Hubs.Equipments
{
    public enum EquipType
    {
        Gear,
        Weapon,
    }
    public enum EquipSlot
    {
        None,
        RightHand,
        LeftHand,
    }
    public interface IEquipment
    {
        void Equip(Transform parent);
        void Unequip();
        EquipType EquipType { get; }
    }
}