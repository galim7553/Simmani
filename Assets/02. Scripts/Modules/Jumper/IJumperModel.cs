using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Modules
{
    public interface IJumperModel
    {
        IJumper.JumpType JumpType { get; }
        float JumpSpeed { get; }
        float JumpHeight { get; }
        
    }
}

