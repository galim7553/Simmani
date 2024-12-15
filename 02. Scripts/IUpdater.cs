using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay
{
    public interface IUpdater
    {
        event Action OnUpdate;
        void AddUpdatable(IUpdatable updatable);
    }
}
