using System.Collections;
using System.Collections.Generic;
using GamePlay.Hubs;
using UnityEngine;

namespace GamePlay.Modules.AI
{
    public interface IAI
    {
        string Key { get; }
        Transform Transform { get; }
        ICoroutineRunner CoroutineRunner { get; }
        float UpdateSpan { get; }

        void Start();
        void Stop();
        void Pause(bool isPause);
    }
}


