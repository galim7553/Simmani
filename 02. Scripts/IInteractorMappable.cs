using System.Collections;
using System.Collections.Generic;
using GamePlay.Modules;
using UnityEngine;

namespace GamePlay
{
    public interface IInteractorMappable
    {
        void AddInteractor(IInteractor interactor);
        void RemoveInteractor(IInteractor interactor);
        bool TryGetInteractor(Collider collider, out IInteractor interactor);
    }

}

