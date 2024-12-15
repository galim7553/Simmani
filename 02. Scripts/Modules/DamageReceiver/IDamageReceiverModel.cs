using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Modules
{
    public interface IDamageReceiverModel
    {
        IDamageReceiverConfig Config { get; }

        event Action OnHealthChanged;
        event Action OnDead;

        float MaxHealth { get; }
        float Health { get; }
        void TakeDamage(float damage);

        void AddHealth(float health);
    }
}