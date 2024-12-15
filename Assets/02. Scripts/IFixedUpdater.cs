using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace GamePlay
{
    public interface IFixedUpdater
    {
        event Action OnFixedUpdate;
        void AddFixedUpdatable(IFixedUpdatable fixedUpdatable);
    }
}


