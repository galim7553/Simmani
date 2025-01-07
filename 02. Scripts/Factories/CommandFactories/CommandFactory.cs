using GamePlay.Commands;
using GamePlay.Configs;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Factories
{
    /// <summary>
    /// 다양한 명령(Command)을 생성하는 팩토리 클래스.
    /// 설정된 명령 키와 세계 모델(WorldModel)을 기반으로 적합한 명령 객체를 생성합니다.
    /// </summary>
    public class CommandFactory : ConfigMapBase<ICommandConfig>, ICommandFactory
    {
        WorldModel _worldModel;

        /// <summary>
        /// 명령 팩토리를 초기화합니다.
        /// </summary>
        /// <param name="configs">명령 설정의 컬렉션.</param>
        /// <param name="worldModel">세계 모델(WorldModel) 객체.</param>
        public CommandFactory(IEnumerable<ICommandConfig> configs, WorldModel worldModel) : base(configs)
        {
            _worldModel = worldModel;
        }

        /// <summary>
        /// 주어진 키를 기반으로 명령(Command)을 생성합니다.
        /// </summary>
        /// <param name="key">명령의 키 값.</param>
        /// <returns>생성된 명령 객체.</returns>
        public ICommand CreateCommand(string key)
        {
            if(_configMap.TryGetValue(key, out var config))
            {
                switch(config)
                {
                    case IShopCommandConfig shopCommandConfig:
                        return new ShopCommand(shopCommandConfig, _worldModel);
                    case IHeroModelCommandConfig heroModelCommandConfig:
                        return new HeroModelCommand(heroModelCommandConfig);
                    case ISansamCommandConfig sansamCommandConfig:
                        return new SansamCommand(sansamCommandConfig, _worldModel);
                    case IConversationCommandConfig conversationCommandConfig:
                        return new ConversationCommand(conversationCommandConfig);
                    case IDaegamCommandConfig daegamCommandConfig:
                        return new DaegamCommand(daegamCommandConfig, _worldModel);
                }
            }

            Debug.LogError($"{key} Command는 존재하지 않습니다!");
            return new HeroModelCommand(new HeroModelCommandConfig());
        }
    }
}


