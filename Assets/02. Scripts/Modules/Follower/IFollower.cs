using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Modules
{
    public interface IFollower : IModule
    {
        event Action<Vector3> OnVelocityChanged;
        void SetTarget(Transform target);
        void SetTarget(Vector3 position);
        void Stop();
        void Pause(bool isPause);
    }
}


