using System;
using UnityEngine;

namespace GamePlay.Modules
{
    /// <summary>
    /// 캐릭터의 이동을 처리하는 기능을 제공하는 인터페이스입니다.
    /// 이동 방향 설정, 이동 속도 설정, 이동 상태 변경 이벤트를 포함합니다.
    /// </summary>
    public interface IMover : IModule
    {
        float Speed { get; }
        event Action<Vector3> OnDirectionChanged;

        /// <summary>
        /// 캐릭터의 이동 방향을 설정합니다. 각 축(x, y, z)으로 이동할 값을 입력합니다.
        /// </summary>
        /// <param name="x">X축 이동 방향 값</param>
        /// <param name="y">Y축 이동 방향 값</param>
        /// <param name="z">Z축 이동 방향 값</param>
        void SetDirection(float x, float y, float z);
    }
}