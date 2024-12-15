using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Modules
{
    public class DamageReceiverModel : ModuleModelBase<IDamageReceiverConfig>, IDamageReceiverModel
    {
        float _bonusHealth = 0;

        public float MaxHealth => Config.BaseHealth + _bonusHealth;

        public float Health { get; private set; }

        public event Action OnHealthChanged;
        public event Action OnDead;

        public DamageReceiverModel(IDamageReceiverConfig config) : base(config)
        {
            Health = MaxHealth;
        }


        public void AddHealth(float amount)
        {
            Health = Mathf.Clamp(Health + amount, 0, MaxHealth);
            OnHealthChanged?.Invoke();
            if (Health < Util.EPSILON)
                OnDead?.Invoke();
        }

        public void TakeDamage(float damage)
        {
            AddHealth(-damage);
            Debug.Log($"{Health}/{MaxHealth}");
        }

        public void AddBonusHealth(float amount)
        {
            _bonusHealth += amount;
            if(amount > 0)
                AddHealth(amount);
        }
    }
}