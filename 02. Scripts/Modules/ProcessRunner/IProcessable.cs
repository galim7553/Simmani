using System;

namespace GamePlay.Modules
{
    /// <summary>
    /// 처리 가능한 작업(Processable)의 인터페이스를 정의합니다.
    /// </summary>
    public interface IProcessable
    {
        /// <summary>
        /// 작업의 유형을 나타냅니다.
        /// </summary>
        public enum ProcessType
        {
            Idle,
            Loot,
        }

        /// <summary>
        /// 작업 유형을 반환합니다.
        /// </summary>
        ProcessType Type { get; }

        /// <summary>
        /// 작업 완료에 필요한 시간(양)을 반환합니다.
        /// </summary>
        float Amount { get; }

        /// <summary>
        /// 작업 성공 시 호출되는 액션입니다.
        /// </summary>
        Action OnSuccess { get; }

        /// <summary>
        /// 작업 실패 시 호출되는 액션입니다.
        /// </summary>
        Action OnFailed { get; }
    }

}

