using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Datas
{
    public interface IConversationModel
    {
        IConversationConfig Config { get; }
        IReadOnlyList<string> Dialogues { get; }
    }
}
