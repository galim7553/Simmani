using System.Collections;
using System.Collections.Generic;
using GamePlay.Configs;
using GamePlay.Hubs;
using UnityEngine;

namespace GamePlay.Factories
{
    public class EnemyModelFactory : ConfigMapBase<EnemyConfig>, IModelFactory<EnemyModel>
    {
        public EnemyModelFactory(IEnumerable<EnemyConfig> configs) : base(configs)
        {
        }

        public EnemyModel CreateModel(string key)
        {
            if(_configMap.TryGetValue(key, out var config))
            {
                return new EnemyModel(config);
            }

            LogMissingConfig(key);
            return new EnemyModel(new EnemyConfig());
        }
    }
}


