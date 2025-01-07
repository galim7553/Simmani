using System.Collections.Generic;
using GamePlay.Configs;
using GamePlay.Hubs;

namespace GamePlay.Factories
{
    /// <summary>
    /// EnemyModel�� �����ϴ� ���丮 Ŭ����.
    /// </summary>
    public class EnemyModelFactory : ConfigMapBase<EnemyConfig>, IModelFactory<EnemyModel>
    {
        /// <summary>
        /// EnemyModelFactory�� �ʱ�ȭ�մϴ�.
        /// </summary>
        /// <param name="configs">EnemyConfig ��ü�� �÷���.</param>
        public EnemyModelFactory(IEnumerable<EnemyConfig> configs) : base(configs)
        {
        }

        /// <summary>
        /// �־��� Ű�� ������� EnemyModel�� �����մϴ�.
        /// </summary>
        /// <param name="key">EnemyConfig�� Ű.</param>
        /// <returns>������ EnemyModel ��ü.</returns>
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


