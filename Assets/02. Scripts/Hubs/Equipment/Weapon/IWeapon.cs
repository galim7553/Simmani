using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Hubs.Equipments
{
    public interface IWeapon : IEquipment
    {
        void SetColliderActive(bool isActive);
    }
}