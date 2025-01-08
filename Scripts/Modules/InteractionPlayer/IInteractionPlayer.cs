namespace GamePlay.Modules
{

    /// <summary>
    /// 상호작용 플레이어 인터페이스.
    /// </summary>
    public interface IInteractionPlayer : IModule
    {

        /// <summary>대화 플레이어.</summary>
        IConversationPlayer ConversationPlayer { get; }

        /// <summary>인벤토리 컨트롤러.</summary>
        IInventoryController InventoryController { get; }

        /// <summary>
        /// 상호작용을 실행합니다.
        /// </summary>
        /// <param name="interactor">상호작용을 시작한 인터랙터.</param>
        void ExecuteInteraction(IInteractor interactor);
    }
}


