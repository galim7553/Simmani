using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GamePlay.Modules.AI
{
    public interface IPatrolBehaviourConfig : IBehaviourConfig
    {
        float MinRadius { get; }
        float MaxRadius { get; }
        float MinSpan { get; }
        float MaxSpan { get; }
        float SpeedRatio { get; }
    }
}