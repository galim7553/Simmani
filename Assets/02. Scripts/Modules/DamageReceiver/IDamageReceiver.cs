using System;
using System.Collections;
using System.Collections.Generic;
using GamePlay.Hubs;
using UnityEngine;

namespace GamePlay.Modules
{
    public interface IDamageReceiver : IModule
    {
        event Action<float> OnDamaged;
        event Action OnDead;
        Transform Transform { get; }
        Collider Collider { get; }
        CharacterTagType CharacterTagType { get; }
        void TakeDamage(float damage);
    }
}


