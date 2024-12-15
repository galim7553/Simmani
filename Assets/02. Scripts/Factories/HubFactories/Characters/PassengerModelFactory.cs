using System.Collections;
using System.Collections.Generic;
using GamePlay.Configs;
using GamePlay.Hubs;
using UnityEngine;

namespace GamePlay.Factories
{

    public class PassengerModelFactory : ConfigMapBase<PassengerConfig>, IModelFactory<PassengerModel>
    {
        ICommandFactory _commandFactory;
        public PassengerModelFactory(IEnumerable<PassengerConfig> configs, ICommandFactory commandFactory) : base(configs)
        {
            _commandFactory = commandFactory;
        }

        public PassengerModel CreateModel(string key)
        {
            if(_configMap.TryGetValue(key, out var config))
                return new PassengerModel(config, _commandFactory);
            LogMissingConfig(key);
            return new PassengerModel(new PassengerConfig(), _commandFactory);
        }
    }

}