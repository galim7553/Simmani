using GamePlay.Modules;

namespace GamePlay.Commands
{
    /// <summary>
    /// ��ȣ�ۿ� ��� �������̽�.
    /// </summary>
    public interface IInteractionCommand : ICommand
    {
        /// <summary>
        /// ��ȣ�ۿ� ����� �����մϴ�.
        /// </summary>
        /// <param name="interactionPlayer">��ȣ�ۿ� �÷��̾�.</param>
        /// <param name="runnable">���μ��� ���� ���� ��ü.</param>
        /// <param name="interactor">��ȣ�ۿ���.</param>
        void Execute(IInteractionPlayer interactionPlayer, IProcessRunnable runnable, IInteractor interactor);
    }

}

