using GamePlay.Commands;
using GamePlay.Configs;
using GamePlay.Datas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Factories
{
    public class CommandFactory : ConfigMapBase<ICommandConfig>, ICommandFactory
    {
        WorldModel _worldModel;
        public CommandFactory(IEnumerable<ICommandConfig> configs, WorldModel worldModel) : base(configs)
        {
            _worldModel = worldModel;
        }

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


