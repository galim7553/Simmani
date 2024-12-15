using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Modules
{
    public interface IConversationPlayer
    {
        bool IsPlaying { get; }
        event Action OnCompleted;
        void StartConversation(string conversationKey);
        void StopConversation();
        
    }

}
