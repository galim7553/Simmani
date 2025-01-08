using System;
using GamePlay.Modules;

namespace GamePlay.Commands
{
    /// <summary>
    /// 대화 명령을 구현하는 클래스.
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
            // 대화 키가 유효하지 않으면 실행하지 않음.
            if (_config.ConversationKeys == null || _config.ConversationKeys.Count == 0) return;

            // 이미 대화 중이거나 다른 작업이 진행 중인 경우 실행하지 않음.
            if (interactionPlayer.ConversationPlayer.IsPlaying == true
                || processRunnable.IsProcessRunnable == false) return;

            _conversationPlayer = interactionPlayer.ConversationPlayer;
            _conversationPlayer.OnCompleted += OnConversationCompleted;

            // 랜덤 대화 시작.
            _conversationPlayer.StartConversation(_config.ConversationKeys.Choose());
            ProcessModel processModel = new ProcessModel(IProcessable.ProcessType.Idle, 0, null, OnProcessFailed);

            processRunnable.BeginProcessWithExternalControl(processModel, out _onRunnableEnded);

            _interactor = interactor;
            _interactor.BeginInteraction();
        }

        void OnProcessFailed()
        {
            // 대화 실패 시 처리.
            _conversationPlayer.StopConversation();
            _interactor.EndInteraction();

            _onRunnableEnded = null;
            _conversationPlayer = null;
            _interactor = null;
        }
        void OnConversationCompleted()
        {
            // 대화 완료 시 처리.
            _onRunnableEnded?.Invoke();
            _onRunnableEnded = null;

            _conversationPlayer.OnCompleted -= OnConversationCompleted;
            _conversationPlayer = null;

            _interactor.EndInteraction();
            _interactor = null;
        }
    }
}