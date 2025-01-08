using GamePlay.Commands;

namespace GamePlay.Modules
{
    /// <summary>
    /// ��ȣ�ۿ� �÷��̾� ���� Ŭ����.
    /// </summary>
    public class InteractionPlayer : ModuleBase, IInteractionPlayer
    {
        IProcessRunnable _processRunnable;
        public IConversationPlayer ConversationPlayer { get; private set; }
        public IInventoryController InventoryController { get; private set; }

        /// <summary>
        /// InteractionPlayer ������.
        /// </summary>
        /// <param name="processRunnable">���μ��� ���� ������ ��ü.</param>
        /// <param name="conversationPlayer">��ȭ �÷��̾�.</param>
        /// <param name="inventoryController">�κ��丮 ��Ʈ�ѷ�.</param>
        public InteractionPlayer(IProcessRunnable processRunnable, IConversationPlayer conversationPlayer, IInventoryController inventoryController)
        {
            _processRunnable = processRunnable;
            ConversationPlayer = conversationPlayer;
            InventoryController = inventoryController;
        }

        public void ExecuteInteraction(IInteractor interactor)
        {
            // ���μ����� ������ �� ���� ��� �Ǵ� �ٸ� �۾��� ���� ���� ��� ��ȯ
            if (_processRunnable.IsProcessRunnable == false) return;
            if (ConversationPlayer.IsPlaying == true || InventoryController.IsActive == true) return;

            // ���ͷ����� ����� ����
            switch (interactor.Model.Command)
            {
                case IInteractionCommand interactionCommand:
                    interactionCommand.Execute(this, _processRunnable, interactor);
                    break;
            }
        }
    }
}


