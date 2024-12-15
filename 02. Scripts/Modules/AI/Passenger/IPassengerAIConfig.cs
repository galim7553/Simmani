using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Modules.AI
{
    public interface IPassengerAIConfig : IAIConfig
    {
        float BaseSpeed { get; }
        string BehaviourKey { get; }
    }


}