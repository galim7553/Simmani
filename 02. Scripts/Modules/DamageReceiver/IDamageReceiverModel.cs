using System;

namespace GamePlay.Modules
{
    /// <summary>
    /// 피격 데이터를 관리하는 인터페이스.
    /// </summary>
    public interface IDamageReceiverModel
    {
        IDamageReceiverConfig Config { get; }

        /// <summary>
        /// 체력이 변경될 때 발생하는 이벤트.
        /// </summary>
        event Action OnHealthChanged;

        /// <summary>
        /// 캐릭터가 사망했을 때 발생하는 이벤트.
        /// </summary>
        event Action OnDead;

        /// <summary>
        /// 최대 체력.
        /// </summary>
        float MaxHealth { get; }

        /// <summary>
        /// 현재 체력.
        /// </summary>
        float Health { get; }

        /// <summary>
        /// 대미지를 받아 체력을 감소시킵니다.
        /// </summary>
        void TakeDamage(float damage);

        /// <summary>
        /// 체력을 회복시킵니다.
        /// </summary>
        void AddHealth(float health);
    }
}
