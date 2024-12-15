using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Modules
{
    public interface IFollowerConfig
    {
        float UpdateSpan { get; }
        float BaseAngularSpeed { get; }
        float BaseRotSpeed { get; }
    }
}


