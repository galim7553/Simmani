using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Modules
{
    public interface IRotatorConfig
    {
        float BaseRotSpeed { get; }
        RotatorLimiter RotatorLimiter { get; }
    }
}


