using System.Collections;
using System.Collections.Generic;
using GamePlay.Commands;
using UnityEngine;

namespace GamePlay.Configs
{
    public interface IDaegamCommandConfig : ICommandConfig
    {
        string GreetingConversationKey { get; }
        string ZeroConversationKey { get; }
        string LackConversationKey { get; }
        string ClearConversationKey { get; }

    }
}


