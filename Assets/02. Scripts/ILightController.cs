using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay
{
    public interface ILightController
    {
        float NormalizedIntensity { get; }
    }
}