using System;
using UnityEngine;

namespace GamePlay.Modules.AI
{
    /// <summary>
    /// 공격 가능한 AI의 동작과 이벤트를 정의하는 인터페이스입니다.
    /// </summary>
    public interface IAttackableAI : IAI
    {
        /// <summary>현재 공격 대상의 Transform.</summary>
        Transform Target { get; }

        /// <summary>AI의 일시 정지 상태를 나타냅니다.</summary>
        bool IsPaused { get; }

        /// <summary>AI가 회전할 때 발생하는 이벤트.</summary>
        event Action<float> OnRotated;

        /// <summary>AI가 공격을 수행합니다.</summary>
        void Attack();

        /// <summary>회전 이벤트를 발생시킵니다.</summary>
        /// <param name="speed">회전 속도.</param>
        void InvokeRotatedEvent(float speed);
        
    }
}


