using System;
using GamePlay.Modules;

namespace GamePlay
{
    /// <summary>
    /// 처리 실행 가능한 객체를 정의하는 인터페이스입니다.
    /// </summary>
    public interface IProcessRunnable
    {
        /// <summary>
        /// 작업 실행 가능 여부를 반환합니다.
        /// </summary>
        bool IsProcessRunnable { get; }

        /// <summary>
        /// 작업을 시작합니다.
        /// </summary>
        /// <param name="processable">처리 가능한 작업</param>
        void BeginProcess(IProcessable processable);

        /// <summary>
        /// 외부 제어와 함께 작업을 시작합니다.
        /// </summary>
        /// <param name="processable">처리 가능한 작업</param>
        /// <param name="onEnded">작업 종료 시 호출되는 액션</param>
        void BeginProcessWithExternalControl(IProcessable processable, out Action onEnded);
    }
}


