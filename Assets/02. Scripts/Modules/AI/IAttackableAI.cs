using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Modules.AI
{
    public interface IAttackableAI : IAI
    {
        Transform Target { get; }
        bool IsPaused { get; }
        event Action<float> OnRotated;
        void Attack();
        void InvokeRotatedEvent(float speed);
        
    }
}


