using System.Collections;
using System.Collections.Generic;
using GamePlay.Commands;
using UnityEngine;

namespace GamePlay.Configs
{
    [CreateAssetMenu(fileName = "CommandConfigs", menuName = "GameConfig/CommandConfigs")]
    public class CommandConfigsScriptableObject : ScriptableObject
    {
        [SerializeField] DaegamCommandConfig _daegamCommandConfig;
        [SerializeField] HeroModelCommandConfig[] _heroModelCommandConfigs;
        [SerializeField] SansamCommandConfig[] _sansamCommandConfigs;
        [SerializeField] ConversationCommandConfig[] _conversationCommandConfigs;
        [SerializeField] ShopCommandConfig[] _shopCommandConfigs;

        public DaegamCommandConfig DaegamCommandConfig => _daegamCommandConfig;
        public IReadOnlyList<HeroModelCommandConfig> HeroModelCommandConfigs => _heroModelCommandConfigs;
        public IReadOnlyList<SansamCommandConfig> SansamCommandConfigs => _sansamCommandConfigs;
        public IReadOnlyList<ConversationCommandConfig> ConversationCommandConfigs => _conversationCommandConfigs;
        public IReadOnlyList<ShopCommandConfig> ShopCommandConfigs => _shopCommandConfigs;
    }

}

