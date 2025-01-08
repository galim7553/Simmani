using System.Collections.Generic;
using GamePlay.Configs;
using GamePlay.Hubs;

namespace GamePlay.Factories
{
    /// <summary>
    /// PassengerModel을 생성하는 팩토리 클래스.
    /// </summary>
    public class PassengerModelFactory : ConfigMapBase<PassengerConfig>, IModelFactory<PassengerModel>
    {
        ICommandFactory _commandFactory;

        /// <summary>
        /// PassengerModelFactory를 초기화합니다.
        /// </summary>
        /// <param name="configs">PassengerConfig 객체의 컬렉션.</param>
        /// <param name="commandFactory">명령 객체를 생성하는 팩토리.</param>
        public PassengerModelFactory(IEnumerable<PassengerConfig> configs, ICommandFactory commandFactory) : base(configs)
        {
            _commandFactory = commandFactory;
        }

        /// <summary>
        /// 주어진 키를 기반으로 PassengerModel을 생성합니다.
        /// </summary>
        /// <param name="key">PassengerConfig의 키.</param>
        /// <returns>생성된 PassengerModel 객체.</returns>

        public PassengerModel CreateModel(string key)
        {
            if(_configMap.TryGetValue(key, out var config))
                return new PassengerModel(config, _commandFactory);
            LogMissingConfig(key);
            return new PassengerModel(new PassengerConfig(), _commandFactory);
        }
    }

}