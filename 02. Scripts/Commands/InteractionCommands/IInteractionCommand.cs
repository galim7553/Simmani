using System.Collections;
using System.Collections.Generic;
using GamePlay.Modules;
using UnityEngine;

namespace GamePlay.Commands
{
    public interface IInteractionCommand : ICommand
    {
        void Execute(IInteractionPlayer interactionPlayer, IProcessRunnable runnable, IInteractor interactor);
    }

}

