using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Modules.AI
{
    public interface IEnemyAIModel : IFollowableAIModel
    {
        IEnemyAIConfig Config { get; }

    }
}


