using GamePlay.Hubs.Equipments;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Modules
{
    public class EquipmentCache
    {
        public IWeapon Weapon { get; private set; }

        public void AddEquipment(IEquipment equipment)
        {
            switch (equipment)
            {
                case IWeapon weapon:
                    Weapon = weapon;
                    break;
            }
        }
        public void RemoveEquipment(IEquipment equipment)
        {
            switch (equipment)
            {
                case IWeapon:
                    Weapon = null;
                    break;
            }
        }
    }
}