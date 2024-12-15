using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Modules
{
    public interface IProcessRunner : IModule
    {
        event Action OnBegan;
        event Action<float> OnProcess;
        event Action OnEnded;

        bool IsRunning { get; }

        void Begin(IProcessable processable);
        void BeginWithExternalControl(IProcessable processable);
        void Fail();
        void End();
    }
}

