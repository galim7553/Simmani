using System.Collections.Generic;
using GamePlay.Configs;
using GamePlay.Hubs;

namespace GamePlay.Factories
{
    /// <summary>
    /// EnemyModel을 생성하는 팩토리 클래스.
    /// </summary>
    public class EnemyModelFactory : ConfigMapBase<EnemyConfig>, IModelFactory<EnemyModel>
    {
        /// <summary>
        /// EnemyModelFactory를 초기화합니다.
        /// </summary>
        /// <param name="configs">EnemyConfig 객체의 컬렉션.</param>
        public EnemyModelFactory(IEnumerable<EnemyConfig> configs) : base(configs)
        {
        }

        /// <summary>
        /// 주어진 키를 기반으로 EnemyModel을 생성합니다.
        /// </summary>
        /// <param name="key">EnemyConfig의 키.</param>
        /// <returns>생성된 EnemyModel 객체.</returns>
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


