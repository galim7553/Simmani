using System.Collections;
using System.Collections.Generic;

namespace GamePlay.Modules.AI
{
    public interface IReturnToSpawnBehaviourConfig : IBehaviourConfig
    {
        float SpeedRatio { get; }
    }
}