using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Modules.AI
{
    public interface IAttackingBehaviourConfig : IBehaviourConfig
    {
        float Span { get; }
        float AngleThreshold { get; }
        float RotSpeed { get; }
    }
}


