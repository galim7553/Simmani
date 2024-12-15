using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Modules
{
    public interface IFatigueConfig
    {
        float Fatigue { get; }
        float FatigueConsumptionSpeed { get; }
    }
}


