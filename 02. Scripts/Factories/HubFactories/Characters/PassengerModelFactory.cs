using System.Collections.Generic;
using GamePlay.Configs;
using GamePlay.Hubs;

namespace GamePlay.Factories
{
    /// <summary>
    /// PassengerModel�� �����ϴ� ���丮 Ŭ����.
    /// </summary>
    public class PassengerModelFactory : ConfigMapBase<PassengerConfig>, IModelFactory<PassengerModel>
    {
        ICommandFactory _commandFactory;

        /// <summary>
        /// PassengerModelFactory�� �ʱ�ȭ�մϴ�.
        /// </summary>
        /// <param name="configs">PassengerConfig ��ü�� �÷���.</param>
        /// <param name="commandFactory">��� ��ü�� �����ϴ� ���丮.</param>
        public PassengerModelFactory(IEnumerable<PassengerConfig> configs, ICommandFactory commandFactory) : base(configs)
        {
            _commandFactory = commandFactory;
        }

        /// <summary>
        /// �־��� Ű�� ������� PassengerModel�� �����մϴ�.
        /// </summary>
        /// <param name="key">PassengerConfig�� Ű.</param>
        /// <returns>������ PassengerModel ��ü.</returns>

        public PassengerModel CreateModel(string key)
        {
            if(_configMap.TryGetValue(key, out var config))
                return new PassengerModel(config, _commandFactory);
            LogMissingConfig(key);
            return new PassengerModel(new PassengerConfig(), _commandFactory);
        }
    }

}