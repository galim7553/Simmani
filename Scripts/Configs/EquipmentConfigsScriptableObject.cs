using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamePlay.Hubs.Equipments;

namespace GamePlay.Configs
{
    [CreateAssetMenu(fileName = "EquipmentConfigs", menuName = "GameConfig/EquipmentConfigs")]
    public class EquipmentConfigsScriptableObject : ScriptableObject
    {
        [SerializeField] GearConfig[] _gearConfigs = new GearConfig[0];
        [SerializeField] WeaponConfig[] _weaponConfigs = new WeaponConfig[0];
        public IReadOnlyList<GearConfig> GearConfigs => _gearConfigs;
        public IReadOnlyList<WeaponConfig> WeaponConfigs => _weaponConfigs;

        private void OnValidate()
        {
            foreach (var config in _gearConfigs)
                config.InvokeOnValidatedEvent();
            foreach (var config in _weaponConfigs)
                config.InvokeOnValidatedEvent();
        }
    }
}


