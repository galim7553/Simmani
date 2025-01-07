using GamePlay.Configs;
using GamePlay.Hubs;
using System.Collections.Generic;

namespace GamePlay.Factories
{
    /// <summary>
    /// InteractableObjectModel�� �����ϰ� �����ϴ� ���丮 Ŭ����.
    /// </summary>
    public class InteractableObjectModelFactory : ConfigMapBase<InteractableObjectConfig>, IModelFactory<InteractableObjectModel>
    {
        ICommandFactory _commandFactory;

        Dictionary<string, InteractableObjectModel> _modelMap = new Dictionary<string, InteractableObjectModel>();

        /// <summary>
        /// InteractableObjectModelFactory�� �ʱ�ȭ�մϴ�.
        /// </summary>
        /// <param name="configs">InteractableObjectConfig ��ü�� �÷���.</param>
        /// <param name="commandFactory">��� ��ü�� �����ϴ� ���丮.</param>
        public InteractableObjectModelFactory(IEnumerable<InteractableObjectConfig> configs, ICommandFactory commandFactory) : base(configs)
        {
            _commandFactory = commandFactory;
        }

        /// <summary>
        /// �־��� Ű�� ������� InteractableObjectModel�� �����ϰų� ��ȯ�մϴ�.
        /// </summary>
        /// <param name="key">Config Ű.</param>
        /// <returns>������ �Ǵ� ������ InteractableObjectModel ��ü.</returns>
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


