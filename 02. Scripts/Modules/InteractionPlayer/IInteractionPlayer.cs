using System.Collections;
using System.Collections.Generic;
using GamePlay.Scene;
using UnityEngine;

namespace GamePlay.Modules
{
    public interface IInteractionPlayer : IModule
    {
        IConversationPlayer ConversationPlayer { get; }
        IInventoryController InventoryController { get; }
        void ExecuteInteraction(IInteractor interactor);
    }
}


