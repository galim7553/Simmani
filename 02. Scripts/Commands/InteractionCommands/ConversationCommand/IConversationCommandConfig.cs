using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Commands
{
    public interface IConversationCommandConfig : ICommandConfig
    {
        IReadOnlyList<string> ConversationKeys { get; }
    }
}