using GamePlay.Configs;
using GamePlay.Hubs;
using System.Collections.Generic;

namespace GamePlay.Factories
{
    /// <summary>
    /// VillagerModel을 생성하는 팩토리 클래스.
    /// </summary>
    public class VillagerModelFactory : ConfigMapBase<VillagerConfig>, IModelFactory<VillagerModel>
    {
        ICommandFactory _commandFactory;

        /// <summary>
        /// VillagerModelFactory를 초기화합니다.
        /// </summary>
        /// <param name="configs">VillagerConfig 객체의 컬렉션.</param>
        /// <param name="commandFactory">명령 객체를 생성하는 팩토리.</param>
        public VillagerModelFactory(IEnumerable<VillagerConfig> configs, ICommandFactory commandFactory) : base(configs)
        {
            _commandFactory = commandFactory;
        }

        /// <summary>
        /// 주어진 키를 기반으로 VillagerModel을 생성합니다.
        /// </summary>
        /// <param name="key">VillagerConfig의 키.</param>
        /// <returns>생성된 VillagerModel 객체.</returns>
        public VillagerModel CreateModel(string key)
        {
            if(_configMap.TryGetValue(key, out var config))
                return new VillagerModel(config, _commandFactory);
            LogMissingConfig(key);
            return new VillagerModel(new VillagerConfig(), _commandFactory);
        }
    }

}