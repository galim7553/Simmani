using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Configs
{
    [CreateAssetMenu(fileName = "VillagerConfigs", menuName = "GameConfig/VillagerConfigs")]
    public class VillagerConfigsScriptableObject : ScriptableObject
    {
        [SerializeField] VillagerConfig[] _villagerConfigs = new VillagerConfig[0];
        [SerializeField] PassengerConfig[] _passengerConfigs = new PassengerConfig[0];
        public IReadOnlyList<VillagerConfig> VillagerConfigs => _villagerConfigs;
        public IReadOnlyList<PassengerConfig> PassengerConfigs => _passengerConfigs;
    }
}