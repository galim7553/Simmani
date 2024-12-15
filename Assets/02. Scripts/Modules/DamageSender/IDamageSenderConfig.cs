using System.Collections;
using System.Collections.Generic;
using GamePlay.Hubs;
using UnityEngine;

namespace GamePlay.Modules
{
    public interface IDamageSenderConfig
    {
        float BaseDamage { get; }
        IReadOnlyList<CharacterTagType> TargetCharacterTagTypes { get; }
    }
}