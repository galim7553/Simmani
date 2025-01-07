namespace GamePlay.Modules
{

    /// <summary>
    /// ��ȣ�ۿ� �÷��̾� �������̽�.
    /// </summary>
    public interface IInteractionPlayer : IModule
    {

        /// <summary>��ȭ �÷��̾�.</summary>
        IConversationPlayer ConversationPlayer { get; }

        /// <summary>�κ��丮 ��Ʈ�ѷ�.</summary>
        IInventoryController InventoryController { get; }

        /// <summary>
        /// ��ȣ�ۿ��� �����մϴ�.
        /// </summary>
        /// <param name="interactor">��ȣ�ۿ��� ������ ���ͷ���.</param>
        void ExecuteInteraction(IInteractor interactor);
    }
}


