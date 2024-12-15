using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Modules
{
    public interface ICombatStaterConfig
    {
        float StiffenTime { get; }
        float AttackingTime { get; }
    }
}


