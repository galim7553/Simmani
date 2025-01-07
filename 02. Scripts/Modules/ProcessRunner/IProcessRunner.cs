using System;

namespace GamePlay.Modules
{
    /// <summary>
    /// 작업 실행을 관리하는 모듈 인터페이스입니다.
    /// </summary>
    public interface IProcessRunner : IModule
    {
        /// <summary>
        /// 작업 시작 시 발생하는 이벤트입니다.
        /// </summary>
        event Action OnBegan;

        /// <summary>
        /// 작업 진행 중 호출되는 이벤트입니다.
        /// 진행률을 전달합니다.
        /// </summary>
        event Action<float> OnProcess;

        /// <summary>
        /// 작업 종료 시 발생하는 이벤트입니다.
        /// </summary>
        event Action OnEnded;

        /// <summary>
        /// 현재 작업 실행 상태를 반환합니다.
        /// </summary>
        bool IsRunning { get; }

        /// <summary>
        /// 작업을 시작합니다.
        /// </summary>
        /// <param name="processable">처리 가능한 작업</param>
        void Begin(IProcessable processable);

        /// <summary>
        /// 외부 제어와 함께 작업을 시작합니다.
        /// </summary>
        /// <param name="processable">처리 가능한 작업</param>
        void BeginWithExternalControl(IProcessable processable);

        /// <summary>
        /// 작업을 실패로 종료합니다.
        /// </summary>
        void Fail();

        /// <summary>
        /// 작업을 정상적으로 종료합니다.
        /// </summary>
        void End();
    }
}

