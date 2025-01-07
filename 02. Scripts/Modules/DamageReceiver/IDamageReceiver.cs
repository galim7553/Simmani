using System;
using GamePlay.Hubs;
using UnityEngine;

namespace GamePlay.Modules
{
    /// <summary>
    /// 피격 시스템의 동작을 정의하는 인터페이스.
    /// </summary>
    public interface IDamageReceiver : IModule
    {
        /// <summary>
        /// 대미지를 받을 때 발생하는 이벤트.
        /// </summary>
        event Action<float> OnDamaged;

        /// <summary>
        /// 캐릭터가 사망했을 때 발생하는 이벤트.
        /// </summary>
        event Action OnDead;

        /// <summary>
        /// 캐릭터의 Transform.
        /// </summary>
        Transform Transform { get; }

        /// <summary>
        /// 캐릭터의 Collider.
        /// </summary>
        Collider Collider { get; }

        /// <summary>
        /// 캐릭터 태그 타입.
        /// </summary>
        CharacterTagType CharacterTagType { get; }

        /// <summary>
        /// 대미지를 받아 처리합니다.
        /// </summary>
        void TakeDamage(float damage);
    }
}