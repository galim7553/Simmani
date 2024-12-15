using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Modules.AI
{
    public interface IPathFollowingBehaviourConfig : IBehaviourConfig
    {
        public enum LoopType
        {
            FowardLoop,
            PingPongLoop
        }

        public LoopType Type { get; }
        public float SpeedRatio { get; }
        public float BrakingDistance { get; }
    }
}