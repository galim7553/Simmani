using GamePlay.Configs;
using GamePlay.Hubs;
using System.Collections.Generic;

namespace GamePlay.Factories
{
    /// <summary>
    /// InteractableObjectModel을 생성하고 관리하는 팩토리 클래스.
    /// </summary>
    public class InteractableObjectModelFactory : ConfigMapBase<InteractableObjectConfig>, IModelFactory<InteractableObjectModel>
    {
        ICommandFactory _commandFactory;

        Dictionary<string, InteractableObjectModel> _modelMap = new Dictionary<string, InteractableObjectModel>();

        /// <summary>
        /// InteractableObjectModelFactory를 초기화합니다.
        /// </summary>
        /// <param name="configs">InteractableObjectConfig 객체의 컬렉션.</param>
        /// <param name="commandFactory">명령 객체를 생성하는 팩토리.</param>
        public InteractableObjectModelFactory(IEnumerable<InteractableObjectConfig> configs, ICommandFactory commandFactory) : base(configs)
        {
            _commandFactory = commandFactory;
        }

        /// <summary>
        /// 주어진 키를 기반으로 InteractableObjectModel을 생성하거나 반환합니다.
        /// </summary>
        /// <param name="key">Config 키.</param>
        /// <returns>생성된 또는 기존의 InteractableObjectModel 객체.</returns>
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


