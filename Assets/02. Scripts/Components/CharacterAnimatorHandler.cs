using System;
using System.Collections;
using System.Collections.Generic;
using GamePlay.Hubs.Equipments;
using UnityEngine;

namespace GamePlay.Components
{
    [RequireComponent(typeof(Animator))]
    public class CharacterAnimatorHandler : MonoBehaviour
    {

        public class Parameters
        {
            public const string ForwardSpeed = "ForwardSpeed";
            public const string RightSpeed = "RightSpeed";
            public const string OnDamaged = "OnDamaged";
            public const string OnAttack = "OnAttack";
            public const string OnDead = "OnDead";
            public const string OnLooting = "OnLooting";
        }

        Animator _animator;

        public event Action<bool> OnSetWeaponColliderActive;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void OnEnable()
        {
            if (_animator.layerCount > 1)
                _animator.SetLayerWeight(1, 1.0f);
        }

        public void SetForwardSpeed(float speed)
        {
            _animator.SetFloat(Parameters.ForwardSpeed, speed);
        }
        public void SetRightSpeed(float speed)
        {
            _animator.SetFloat(Parameters.RightSpeed, speed);
        }
        public void SetOnDamagedTrigger()
        {
            _animator.SetTrigger(Parameters.OnDamaged);
        }
        public void SetOnAttackTrigger()
        {
            _animator.SetTrigger(Parameters.OnAttack);
        }
        public void SetOnDeadTrigger()
        {
            if (_animator.layerCount > 1)
                _animator.SetLayerWeight(1, 0.0f);
            _animator.SetTrigger(Parameters.OnDead);
        }
        public void SetOnLooting(bool isLooting)
        {
            _animator.SetBool(Parameters.OnLooting, isLooting);
        }
        public void SetWeaponColliderActive(int value)
        {
            OnSetWeaponColliderActive?.Invoke(value != 0);
        }

        public void Clear()
        {
            OnSetWeaponColliderActive = null;
        }
    }
}


