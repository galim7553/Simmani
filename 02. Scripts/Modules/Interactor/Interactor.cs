using GamePlay.Commands;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Modules
{
    public class Interactor : ModuleBase, IInteractor
    {
        public IInteractorModel Model { get; private set; }
        public Collider Collider { get; private set; }

        public event Action OnInteractionBegan;
        public event Action OnInteractionEnded;

        public Interactor(IInteractorModel model, Collider collider, IInteractorMappable interactorMappable)
        {
            Model = model;
            Collider = collider;
            interactorMappable.AddInteractor(this);
        }

        public void BeginInteraction()
        {
            OnInteractionBegan?.Invoke();
        }

        public void EndInteraction()
        {
            OnInteractionEnded?.Invoke();
        }
    }
}


