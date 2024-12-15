using System;
using System.Collections;
using System.Collections.Generic;
using GamePlay.Hubs;
using UnityEngine;

namespace GamePlay.Modules
{
    public class DamageReceiver : ModuleBase, IDamageReceiver
    {
        IDamageReceiverModel _model;
        IDamageReceiverMappable _damageReceiverMappable;
        public Transform Transform { get; private set; }
        public Collider Collider { get; private set; }
        public CharacterTagType CharacterTagType => _model.Config.CharacterTagType;

        

        public event Action<float> OnDamaged;
        public event Action OnDead;

        public DamageReceiver(IDamageReceiverModel model, Transform transform, Collider collider, IDamageReceiverMappable damageReceiverMappable)
        {
            _model = model;
            Transform = transform;
            Collider = collider;
            _damageReceiverMappable = damageReceiverMappable;

            _damageReceiverMappable.AddDamageReceiver(this);

            _model.OnDead += InvokeOnDeadEvent;
        }

        public void TakeDamage(float damage)
        {
            if (!IsActive) return;

            _model.TakeDamage(damage);
            OnDamaged?.Invoke(damage);
        }

        void InvokeOnDeadEvent()
        {
            OnDead?.Invoke();
        }

        public override void Clear()
        {
            _model.OnDead -= InvokeOnDeadEvent;

            OnDamaged = null;
            OnDead = null;
            _damageReceiverMappable.RemoveDamageReceiver(this);
        }
    }
}


