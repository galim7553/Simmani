using System;
using GamePlay.Hubs;
using UnityEngine;

namespace GamePlay.Modules
{
    /// <summary>
    /// 피격 로직을 구현하는 클래스.
    /// </summary>
    public class DamageReceiver : ModuleBase, IDamageReceiver
    {
        IDamageReceiverModel _model;
        IDamageReceiverMappable _damageReceiverMappable;

        public Transform Transform { get; private set; }
        public Collider Collider { get; private set; }
        public CharacterTagType CharacterTagType => _model.Config.CharacterTagType;

        public event Action<float> OnDamaged;
        public event Action OnDead;

        /// <summary>
        /// DamageReceiver 생성자.
        /// </summary>
        /// <param name="model">피격 모델</param>
        /// <param name="transform">캐릭터의 Transform</param>
        /// <param name="collider">캐릭터의 Collider</param>
        /// <param name="damageReceiverMappable">피격 객체를 관리하는 맵퍼</param>
        public DamageReceiver(IDamageReceiverModel model, Transform transform, Collider collider, IDamageReceiverMappable damageReceiverMappable)
        {
            _model = model;
            Transform = transform;
            Collider = collider;
            _damageReceiverMappable = damageReceiverMappable;

            _damageReceiverMappable.AddDamageReceiver(this);
            _model.OnDead += InvokeOnDeadEvent;
        }

        /// <summary>
        /// 대미지를 받아 처리합니다.
        /// </summary>
        public void TakeDamage(float damage)
        {
            if (!IsActive) return;

            _model.TakeDamage(damage);
            OnDamaged?.Invoke(damage);
        }

        /// <summary>
        /// 사망 이벤트를 호출합니다.
        /// </summary>
        void InvokeOnDeadEvent()
        {
            OnDead?.Invoke();
        }

        /// <summary>
        /// 모듈을 초기화합니다.
        /// </summary>
        public override void Clear()
        {
            _model.OnDead -= InvokeOnDeadEvent;
            OnDamaged = null;
            OnDead = null;
            _damageReceiverMappable.RemoveDamageReceiver(this);
        }
    }
}
