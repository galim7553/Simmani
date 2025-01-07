using System;
using UnityEngine;

namespace GamePlay.Modules
{
    /// <summary>
    /// �ǰ� �����͸� �����ϴ� �⺻ ���� Ŭ����.
    /// </summary>
    public class DamageReceiverModel : ModuleModelBase<IDamageReceiverConfig>, IDamageReceiverModel
    {
        float _bonusHealth = 0;

        /// <summary>
        /// �ִ� ü�� (�⺻ ü�� + ���ʽ� ü��).
        /// </summary>
        public float MaxHealth => Config.BaseHealth + _bonusHealth;

        /// <summary>
        /// ���� ü��.
        /// </summary>
        public float Health { get; private set; }

        public event Action OnHealthChanged;
        public event Action OnDead;

        /// <summary>
        /// DamageReceiverModel ������.
        /// </summary>
        /// <param name="config">�ǰ� ������</param>
        public DamageReceiverModel(IDamageReceiverConfig config) : base(config)
        {
            Health = MaxHealth;
        }

        /// <summary>
        /// ü���� ȸ���ϰų� ���ҽ�ŵ�ϴ�.
        /// </summary>
        public void AddHealth(float amount)
        {
            Health = Mathf.Clamp(Health + amount, 0, MaxHealth);
            OnHealthChanged?.Invoke();

            // ü���� 0 �����̸� ��� �̺�Ʈ ȣ��
            if (Health < Util.EPSILON)
                OnDead?.Invoke();
        }

        /// <summary>
        /// ������� �޾� ü���� ���ҽ�ŵ�ϴ�.
        /// </summary>
        public void TakeDamage(float damage)
        {
            AddHealth(-damage);
            Debug.Log($"{Health}/{MaxHealth}");
        }

        /// <summary>
        /// ���ʽ� ü���� �߰��մϴ�.
        /// </summary>
        public void AddBonusHealth(float amount)
        {
            _bonusHealth += amount;
            if (amount > 0)
                AddHealth(amount);
        }
    }
}
