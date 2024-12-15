using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Modules
{
    public interface IProcessable
    {
        public enum ProcessType
        {
            Idle,
            Loot,
        }
        ProcessType Type { get; }
        float Amount { get; }
        Action OnSuccess { get; }
        Action OnFailed { get; }
    }

}

