using GamePlay.Commands;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Modules
{
    public interface IInteractor : IModule
    {
        IInteractorModel Model { get; }

        event Action OnInteractionBegan;
        event Action OnInteractionEnded;
        Collider Collider { get; }

        void BeginInteraction();
        void EndInteraction();
    }
}