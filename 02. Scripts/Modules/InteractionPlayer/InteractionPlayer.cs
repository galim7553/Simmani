using GamePlay.Commands;
using GamePlay.Scene;

namespace GamePlay.Modules
{
    public class InteractionPlayer : ModuleBase, IInteractionPlayer
    {
        IProcessRunnable _processRunnable;
        public IConversationPlayer ConversationPlayer { get; private set; }
        public IInventoryController InventoryController { get; private set; }

        public InteractionPlayer(IProcessRunnable processRunnable, IConversationPlayer conversationPlayer, IInventoryController inventoryController)
        {
            _processRunnable = processRunnable;
            ConversationPlayer = conversationPlayer;
            InventoryController = inventoryController;
        }

        public void ExecuteInteraction(IInteractor interactor)
        {
            if (_processRunnable.IsProcessRunnable == false) return;
            if (ConversationPlayer.IsPlaying == true || InventoryController.IsActive == true) return;

            switch (interactor.Model.Command)
            {
                case IInteractionCommand interactionCommand:
                    interactionCommand.Execute(this, _processRunnable, interactor);
                    break;
            }
        }
    }
}


