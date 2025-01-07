using GamePlay.Modules;

namespace GamePlay.Commands
{
    /// <summary>
    /// 상호작용 명령 인터페이스.
    /// </summary>
    public interface IInteractionCommand : ICommand
    {
        /// <summary>
        /// 상호작용 명령을 실행합니다.
        /// </summary>
        /// <param name="interactionPlayer">상호작용 플레이어.</param>
        /// <param name="runnable">프로세스 실행 가능 객체.</param>
        /// <param name="interactor">상호작용자.</param>
        void Execute(IInteractionPlayer interactionPlayer, IProcessRunnable runnable, IInteractor interactor);
    }

}

