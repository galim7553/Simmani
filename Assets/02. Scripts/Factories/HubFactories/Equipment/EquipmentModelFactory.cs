using GamePlay.Configs;
using GamePlay.Datas;
using GamePlay.Hubs.Equipments;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Factories
{
    public class EquipmentModelFactory : ConfigMapBase<EquipmentConfig>, IModelFactory<IEquipmentModel, ItemData>
    {
        public EquipmentModelFactory(IEnumerable<EquipmentConfig> configs) : base(configs)
        {
        }

        public IEquipmentModel CreateModel(ItemData itemData)
        {
            if (_configMap.TryGetValue(itemData.Key, out var config))
            {
                switch (config)
                {
                    case GearConfig gearConfig:
                        return new GearModel(gearConfig, itemData);
                    case WeaponConfig weaponConfig:
                        return new WeaponModel(weaponConfig, itemData);
                }
            }
            LogMissingConfig(itemData.Key);

            // 후에 기본값 처리
            return null;
        }
    }
}


