using GamePlay.Modules;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Modules
{
    public interface IJumpable
    {
        IJumper.JumpState JumpState { get; }
        void Jump();
    }
}


