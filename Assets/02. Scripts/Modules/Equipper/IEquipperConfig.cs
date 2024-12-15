using GamePlay.Hubs.Equipments;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Modules
{
    public interface IEquipperConfig
    {
        IEnumerable<EquipSlot> EquipSlots { get; }
    }

}

