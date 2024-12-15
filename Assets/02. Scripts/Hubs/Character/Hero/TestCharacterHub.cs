using System;
using System.Collections;
using System.Collections.Generic;
using GamePlay.Components;
using GamePlay.Modules;
using UnityEngine;
using UnityEngine.AI;

namespace GamePlay.Hubs
{
    public class TestCharacterHub : ObjectHub, IFixedUpdater
    {

        public Transform _followTarget;

        public event Action OnFixedUpdate;

        public override void Initialize()
        {
            _followTarget = FindObjectOfType<HeroHub>().transform;
            Modules.Get<IFollower>().SetTarget(_followTarget);
            
            CharacterAnimatorHandler characterAnimatorHandler = GetComponentInChildren<CharacterAnimatorHandler>();
            Modules.Get<IFollower>().OnVelocityChanged += (velocity) =>
            {
                characterAnimatorHandler.SetForwardSpeed(velocity.z);
                characterAnimatorHandler.SetRightSpeed(velocity.x);
            };

            Modules.Get<IDamageReceiver>().OnDamaged += (damaged) =>
            {
                characterAnimatorHandler.SetOnDamagedTrigger();
            };
        }

        private void FixedUpdate()
        {
            OnFixedUpdate?.Invoke();
        }

        public void AddFixedUpdatable(IFixedUpdatable fixedUpdatable)
        {
            OnFixedUpdate += fixedUpdatable.OnFixedUpdate;
        }
    }
}

