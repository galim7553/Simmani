using GamePlay.Commands;

namespace GamePlay.Modules
{
    /// <summary>
    /// 상호작용 플레이어 구현 클래스.
    /// </summary>
    public class InteractionPlayer : ModuleBase, IInteractionPlayer
    {
        IProcessRunnable _processRunnable;
        public IConversationPlayer ConversationPlayer { get; private set; }
        public IInventoryController InventoryController { get; private set; }

        /// <summary>
        /// InteractionPlayer 생성자.
        /// </summary>
        /// <param name="processRunnable">프로세스 실행 가능한 객체.</param>
        /// <param name="conversationPlayer">대화 플레이어.</param>
        /// <param name="inventoryController">인벤토리 컨트롤러.</param>
        public InteractionPlayer(IProcessRunnable processRunnable, IConversationPlayer conversationPlayer, IInventoryController inventoryController)
        {
            _processRunnable = processRunnable;
            ConversationPlayer = conversationPlayer;
            InventoryController = inventoryController;
        }

        public void ExecuteInteraction(IInteractor interactor)
        {
            // 프로세스를 실행할 수 없는 경우 또는 다른 작업이 진행 중인 경우 반환
            if (_processRunnable.IsProcessRunnable == false) return;
            if (ConversationPlayer.IsPlaying == true || InventoryController.IsActive == true) return;

            // 인터랙터의 명령을 실행
            switch (interactor.Model.Command)
            {
                case IInteractionCommand interactionCommand:
                    interactionCommand.Execute(this, _processRunnable, interactor);
                    break;
            }
        }
    }
}


