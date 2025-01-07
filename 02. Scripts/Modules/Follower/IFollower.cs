using System;
using UnityEngine;

namespace GamePlay.Modules
{
    /// <summary>
    /// 대상(Transform 또는 위치) 추적을 위한 모듈 인터페이스.
    /// </summary>
    public interface IFollower : IModule
    {
        /// <summary>속도 변경 이벤트.</summary>
        event Action<Vector3> OnVelocityChanged;

        /// <summary>대상 Transform 설정.</summary>
        void SetTarget(Transform target);

        /// <summary>대상 위치(Vector3) 설정.</summary>
        void SetTarget(Vector3 position);

        /// <summary>추적 정지.</summary>
        void Stop();

        /// <summary>추적 일시 정지/재개.</summary>
        void Pause(bool isPause);
    }
}


