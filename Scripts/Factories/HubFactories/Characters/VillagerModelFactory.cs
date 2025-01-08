using GamePlay.Configs;
using GamePlay.Hubs;
using System.Collections.Generic;

namespace GamePlay.Factories
{
    /// <summary>
    /// VillagerModel�� �����ϴ� ���丮 Ŭ����.
    /// </summary>
    public class VillagerModelFactory : ConfigMapBase<VillagerConfig>, IModelFactory<VillagerModel>
    {
        ICommandFactory _commandFactory;

        /// <summary>
        /// VillagerModelFactory�� �ʱ�ȭ�մϴ�.
        /// </summary>
        /// <param name="configs">VillagerConfig ��ü�� �÷���.</param>
        /// <param name="commandFactory">��� ��ü�� �����ϴ� ���丮.</param>
        public VillagerModelFactory(IEnumerable<VillagerConfig> configs, ICommandFactory commandFactory) : base(configs)
        {
            _commandFactory = commandFactory;
        }

        /// <summary>
        /// �־��� Ű�� ������� VillagerModel�� �����մϴ�.
        /// </summary>
        /// <param name="key">VillagerConfig�� Ű.</param>
        /// <returns>������ VillagerModel ��ü.</returns>
        public VillagerModel CreateModel(string key)
        {
            if(_configMap.TryGetValue(key, out var config))
                return new VillagerModel(config, _commandFactory);
            LogMissingConfig(key);
            return new VillagerModel(new VillagerConfig(), _commandFactory);
        }
    }

}