using System;
using GamePlay.Hubs;
using UnityEngine;

namespace GamePlay.Modules
{
    /// <summary>
    /// �ǰ� ������ �����ϴ� Ŭ����.
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
        /// DamageReceiver ������.
        /// </summary>
        /// <param name="model">�ǰ� ��</param>
        /// <param name="transform">ĳ������ Transform</param>
        /// <param name="collider">ĳ������ Collider</param>
        /// <param name="damageReceiverMappable">�ǰ� ��ü�� �����ϴ� ����</param>
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
        /// ������� �޾� ó���մϴ�.
        /// </summary>
        public void TakeDamage(float damage)
        {
            if (!IsActive) return;

            _model.TakeDamage(damage);
            OnDamaged?.Invoke(damage);
        }

        /// <summary>
        /// ��� �̺�Ʈ�� ȣ���մϴ�.
        /// </summary>
        void InvokeOnDeadEvent()
        {
            OnDead?.Invoke();
        }

        /// <summary>
        /// ����� �ʱ�ȭ�մϴ�.
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
