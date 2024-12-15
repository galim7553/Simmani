using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Modules
{
    public interface IJumperConfig
    {
        IJumper.JumpType JumpType { get; }
        float BaseJumpSpeed { get; }
        float BaseJumpHeight { get; }
    }
}


