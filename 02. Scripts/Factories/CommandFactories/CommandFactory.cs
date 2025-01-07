using GamePlay.Commands;
using GamePlay.Configs;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Factories
{
    /// <summary>
    /// �پ��� ���(Command)�� �����ϴ� ���丮 Ŭ����.
    /// ������ ��� Ű�� ���� ��(WorldModel)�� ������� ������ ��� ��ü�� �����մϴ�.
    /// </summary>
    public class CommandFactory : ConfigMapBase<ICommandConfig>, ICommandFactory
    {
        WorldModel _worldModel;

        /// <summary>
        /// ��� ���丮�� �ʱ�ȭ�մϴ�.
        /// </summary>
        /// <param name="configs">��� ������ �÷���.</param>
        /// <param name="worldModel">���� ��(WorldModel) ��ü.</param>
        public CommandFactory(IEnumerable<ICommandConfig> configs, WorldModel worldModel) : base(configs)
        {
            _worldModel = worldModel;
        }

        /// <summary>
        /// �־��� Ű�� ������� ���(Command)�� �����մϴ�.
        /// </summary>
        /// <param name="key">����� Ű ��.</param>
        /// <returns>������ ��� ��ü.</returns>
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

            Debug.LogError($"{key} Command�� �������� �ʽ��ϴ�!");
            return new HeroModelCommand(new HeroModelCommandConfig());
        }
    }
}


