using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Modules
{
    public interface IRotatorModel
    {
        float RotSpeed { get; }
        RotatorLimiter RotatorLimiter { get; }
    }
}


