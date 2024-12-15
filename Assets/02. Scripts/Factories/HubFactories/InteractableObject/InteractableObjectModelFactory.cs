using GamePlay.Configs;
using GamePlay.Hubs;
using GamePlay.Modules;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Factories
{
    public class InteractableObjectModelFactory : ConfigMapBase<InteractableObjectConfig>, IModelFactory<InteractableObjectModel>
    {
        ICommandFactory _commandFactory;

        Dictionary<string, InteractableObjectModel> _modelMap = new Dictionary<string, InteractableObjectModel>();

        public InteractableObjectModelFactory(IEnumerable<InteractableObjectConfig> configs, ICommandFactory commandFactory) : base(configs)
        {
            _commandFactory = commandFactory;
        }

        public InteractableObjectModel CreateModel(string key)
        {
            if (_modelMap.TryGetValue(key, out var model))
                return model;

            if(_configMap.TryGetValue(key, out var config))
            {
                model = new InteractableObjectModel(config, _commandFactory);
                _modelMap[key] = model;
                return model;
            }

            LogMissingConfig(key);
            return new InteractableObjectModel(new InteractableObjectConfig(), _commandFactory);
        }

    }
}


