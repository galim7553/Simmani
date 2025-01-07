using System;
using UnityEngine;

namespace GamePlay.Components
{
    /// <summary>
    /// 캐릭터 애니메이터를 제어하는 컴포넌트.
    /// </summary>
    [RequireComponent(typeof(Animator))]
    public class CharacterAnimatorHandler : MonoBehaviour
    {
        /// <summary>
        /// 애니메이터 매개변수 상수 정의.
        /// </summary>
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

        /// <summary>
        /// 무기 콜라이더 활성화 이벤트.
        /// </summary>
        public event Action<bool> OnSetWeaponColliderActive;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void OnEnable()
        {
            // 보조 애니메이터 레이어 활성화
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


