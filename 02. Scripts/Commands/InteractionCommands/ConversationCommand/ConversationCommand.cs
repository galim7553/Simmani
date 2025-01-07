using System;
using GamePlay.Modules;

namespace GamePlay.Commands
{
    /// <summary>
    /// ��ȭ ����� �����ϴ� Ŭ����.
    /// </summary>
    public class ConversationCommand : IInteractionCommand
    {
        IConversationCommandConfig _config;

        IConversationPlayer _conversationPlayer;
        Action _onRunnableEnded;
        IInteractor _interactor;

        public ConversationCommand(IConversationCommandConfig config)
        {
            _config = config;
        }

        public void Execute(IInteractionPlayer interactionPlayer, IProcessRunnable processRunnable, IInteractor interactor)
        {
            // ��ȭ Ű�� ��ȿ���� ������ �������� ����.
            if (_config.ConversationKeys == null || _config.ConversationKeys.Count == 0) return;

            // �̹� ��ȭ ���̰ų� �ٸ� �۾��� ���� ���� ��� �������� ����.
            if (interactionPlayer.ConversationPlayer.IsPlaying == true
                || processRunnable.IsProcessRunnable == false) return;

            _conversationPlayer = interactionPlayer.ConversationPlayer;
            _conversationPlayer.OnCompleted += OnConversationCompleted;

            // ���� ��ȭ ����.
            _conversationPlayer.StartConversation(_config.ConversationKeys.Choose());
            ProcessModel processModel = new ProcessModel(IProcessable.ProcessType.Idle, 0, null, OnProcessFailed);

            processRunnable.BeginProcessWithExternalControl(processModel, out _onRunnableEnded);

            _interactor = interactor;
            _interactor.BeginInteraction();
        }

        void OnProcessFailed()
        {
            // ��ȭ ���� �� ó��.
            _conversationPlayer.StopConversation();
            _interactor.EndInteraction();

            _onRunnableEnded = null;
            _conversationPlayer = null;
            _interactor = null;
        }
        void OnConversationCompleted()
        {
            // ��ȭ �Ϸ� �� ó��.
            _onRunnableEnded?.Invoke();
            _onRunnableEnded = null;

            _conversationPlayer.OnCompleted -= OnConversationCompleted;
            _conversationPlayer = null;

            _interactor.EndInteraction();
            _interactor = null;
        }
    }
}