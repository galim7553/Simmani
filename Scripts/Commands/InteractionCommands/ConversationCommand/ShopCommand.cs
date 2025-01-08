using System;
using GamePlay.Datas;
using GamePlay.Modules;

namespace GamePlay.Commands
{
    /// <summary>
    /// 상점 명령을 구현하는 클래스.
    /// </summary>
    public class ShopCommand : IInteractionCommand
    {
        IShopCommandConfig _config;
        WorldModel _worldModel;
        ShopModel _shopModel;

        IConversationPlayer _conversationPlayer;
        IInventoryController _inventoryController;
        Action _onRunnableEnded;

        /// <summary>
        /// ShopCommand의 생성자.
        /// </summary>
        /// <param name="config">상점 명령 설정.</param>
        /// <param name="worldModel">월드 모델.</param>
        public ShopCommand(IShopCommandConfig config, WorldModel worldModel)
        {
            _config = config;
            _worldModel = worldModel;
            _shopModel = new ShopModel(_config, _worldModel.ItemModelFactory);
        }

        /// <summary>
        /// 상호작용 명령 실행.
        /// </summary>
        /// <param name="interactionPlayer">상호작용 플레이어.</param>
        /// <param name="processRunnable">작업 실행 가능한 객체.</param>
        /// <param name="interactor">상호작용 대상.</param>
        public void Execute(IInteractionPlayer interactionPlayer, IProcessRunnable processRunnable, IInteractor interactor)
        {
            // 대화 키가 유효하지 않으면 실행하지 않음.
            if (_config.ConversationKeys == null || _config.ConversationKeys.Count == 0) return;

            // 이미 대화 중이거나 다른 작업이 진행 중인 경우 실행하지 않음.
            if (interactionPlayer.ConversationPlayer.IsPlaying == true
                || processRunnable.IsProcessRunnable == false) return;

            _conversationPlayer = interactionPlayer.ConversationPlayer;
            _inventoryController = interactionPlayer.InventoryController;
            _conversationPlayer.OnCompleted += OnConversationCompleted;

            // 랜덤 대화 시작.
            _conversationPlayer.StartConversation(_config.ConversationKeys.Choose());
            ProcessModel processModel = new ProcessModel(IProcessable.ProcessType.Idle, 0, null, OnProcessFailed);

            // 작업 실행 및 종료 시 호출할 액션 설정.
            processRunnable.BeginProcessWithExternalControl(processModel, out _onRunnableEnded);
        }

        /// <summary>
        /// 작업 실패 시 호출되는 메서드.
        /// </summary>
        void OnProcessFailed()
        {
            _conversationPlayer.StopConversation();
            _onRunnableEnded = null;
            _conversationPlayer = null;
            _inventoryController = null;
        }

        /// <summary>
        /// 대화 완료 시 호출되는 메서드.
        /// </summary>
        void OnConversationCompleted()
        {
            _onRunnableEnded?.Invoke();
            _onRunnableEnded = null;
            _conversationPlayer.OnCompleted -= OnConversationCompleted;
            _conversationPlayer = null;

            _inventoryController.DisplayInventory(true, _shopModel);
            _inventoryController = null;

        }
    }
}

