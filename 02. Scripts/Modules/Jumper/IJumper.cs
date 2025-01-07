using System;

namespace GamePlay.Modules
{
    /// <summary>
    /// 점프 동작을 정의하는 인터페이스.
    /// </summary>
    public interface IJumper : IModule
    {
        /// <summary>
        /// 점프 상태를 나타내는 열거형.
        /// </summary>
        enum JumpState
        {
            OnGround,   // 지면에 있음
            Jumping,    // 점프 중
            Falling     // 공중에서 떨어짐
        }

        /// <summary>
        /// 점프 타입을 나타내는 열거형.
        /// </summary>
        enum JumpType
        {
            Velocity,   // 속도를 이용한 점프
            Height      // 높이를 기준으로 계산한 점프
        }

        /// <summary>
        /// 점프 상태가 변경될 때 발생하는 이벤트.
        /// </summary>
        event Action<JumpState> OnJumpStateChanged;

        /// <summary>
        /// 현재 점프 상태.
        /// </summary>
        JumpState State { get; }

        /// <summary>
        /// 점프 동작을 수행합니다.
        /// </summary>
        void Jump();
    }
}
