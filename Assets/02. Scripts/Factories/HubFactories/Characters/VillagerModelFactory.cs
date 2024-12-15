using GamePlay.Configs;
using GamePlay.Hubs;
using System.Collections.Generic;

namespace GamePlay.Factories
{
    public class VillagerModelFactory : ConfigMapBase<VillagerConfig>, IModelFactory<VillagerModel>
    {
        ICommandFactory _commandFactory;
        public VillagerModelFactory(IEnumerable<VillagerConfig> configs, ICommandFactory commandFactory) : base(configs)
        {
            _commandFactory = commandFactory;
        }

        public VillagerModel CreateModel(string key)
        {
            if(_configMap.TryGetValue(key, out var config))
                return new VillagerModel(config, _commandFactory);
            LogMissingConfig(key);
            return new VillagerModel(new VillagerConfig(), _commandFactory);
        }
    }

}