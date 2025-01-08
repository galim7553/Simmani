using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Configs
{
    [CreateAssetMenu(fileName = "EnemyConfigs", menuName = "GameConfig/EnemyConfigs")]
    public class EnemyConfigsScriptableObject : ScriptableObject
    {
        [SerializeField] List<EnemyConfig> _enemyConfigs;
        public IReadOnlyList<EnemyConfig> EnemyConfigs => _enemyConfigs;
    }
}

