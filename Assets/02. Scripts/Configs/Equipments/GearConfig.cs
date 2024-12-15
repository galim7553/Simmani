using GamePlay.Hubs.Equipments;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Configs
{
    [Serializable]
    public class GearConfig : EquipmentConfig
    {
        public override EquipType EquipType => EquipType.Gear;
    }
}


