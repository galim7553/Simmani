using System;
using System.Collections;
using System.Collections.Generic;
using GamePlay.Hubs.Equipments;
using UnityEngine;

namespace GamePlay.Modules
{
    public interface IEquipper : IModule
    {
        EquipmentCache Cache { get; }

        void Initialize();
        void Equip(EquipSlot slot, IEquipmentModel model);
        void Unequip(EquipSlot slot, IEquipmentModel model);        
    }
}