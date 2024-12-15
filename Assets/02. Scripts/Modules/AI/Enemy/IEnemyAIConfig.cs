using GamePlay.Hubs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Modules.AI
{
    public interface IEnemyAIConfig : IAIConfig
    {
        float BaseSpeed { get; }
        string IdleBehaviourKey { get; }
        string TraceBehaviourKey {get; }
        string AttackingBehaviourKey { get; }
        float DetectionLength { get; }
        float TraceLength { get; }
        float AttackLength { get; }
        float HitSphereRadius { get; }
    }
}


