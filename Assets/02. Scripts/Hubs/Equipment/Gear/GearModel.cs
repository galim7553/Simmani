using GamePlay.Configs;
using GamePlay.Datas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Hubs.Equipments
{
    public class GearModel : EquipmentModel<GearConfig>, IGearModel
    {
        public GearModel(GearConfig config, ItemData itemData) : base(config, itemData)
        {
        }

        
    }
}

