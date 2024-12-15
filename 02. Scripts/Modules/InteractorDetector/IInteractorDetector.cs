using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Modules
{
    public interface IInteractorDetector : IModule
    {
        event Action<IInteractor> OnInteractorDetected;
        event Action OnInteractorMissed;
    }
}


