using System;
using System.Collections;
using System.Collections.Generic;
using GamePlay.Modules;
using UnityEngine;

namespace GamePlay
{
    public interface IProcessRunnable
    {
        bool IsProcessRunnable { get; }
        void BeginProcess(IProcessable processable);
        void BeginProcessWithExternalControl(IProcessable processable, out Action onEnded);
    }
}


