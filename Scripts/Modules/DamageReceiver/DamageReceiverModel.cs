using System;
using UnityEngine;

namespace GamePlay.Modules
{
    /// <summary>
    /// 피격 데이터를 관리하는 기본 구현 클래스.
    /// </summary>
    public class DamageReceiverModel : ModuleModelBase<IDamageReceiverConfig>, IDamageReceiverModel
    {
        float _bonusHealth = 0;

        /// <summary>
        /// 최대 체력 (기본 체력 + 보너스 체력).
        /// </summary>
        public float MaxHealth => Config.BaseHealth + _bonusHealth;

        /// <summary>
        /// 현재 체력.
        /// </summary>
        public float Health { get; private set; }

        public event Action OnHealthChanged;
        public event Action OnDead;

        /// <summary>
        /// DamageReceiverModel 생성자.
        /// </summary>
        /// <param name="config">피격 설정값</param>
        public DamageReceiverModel(IDamageReceiverConfig config) : base(config)
        {
            Health = MaxHealth;
        }

        /// <summary>
        /// 체력을 회복하거나 감소시킵니다.
        /// </summary>
        public void AddHealth(float amount)
        {
            Health = Mathf.Clamp(Health + amount, 0, MaxHealth);
            OnHealthChanged?.Invoke();

            // 체력이 0 이하이면 사망 이벤트 호출
            if (Health < Util.EPSILON)
                OnDead?.Invoke();
        }

        /// <summary>
        /// 대미지를 받아 체력을 감소시킵니다.
        /// </summary>
        public void TakeDamage(float damage)
        {
            AddHealth(-damage);
            Debug.Log($"{Health}/{MaxHealth}");
        }

        /// <summary>
        /// 보너스 체력을 추가합니다.
        /// </summary>
        public void AddBonusHealth(float amount)
        {
            _bonusHealth += amount;
            if (amount > 0)
                AddHealth(amount);
        }
    }
}
