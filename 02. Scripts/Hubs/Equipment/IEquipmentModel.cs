using GamePlay.Configs;
using GamePlay.Datas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Hubs.Equipments
{
    public interface IEquipmentModel : IItemUsage
    {
        EquipmentConfig Config { get; }
        bool HasEquipped { get; }

        public void SetHasEquipped(bool hasEquipped);
    }

}

