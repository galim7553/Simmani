using System;
using GamePlay.Datas;
using GamePlay.Modules;

namespace GamePlay.Commands
{
    /// <summary>
    /// ���� ����� �����ϴ� Ŭ����.
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
        /// ShopCommand�� ������.
        /// </summary>
        /// <param name="config">���� ��� ����.</param>
        /// <param name="worldModel">���� ��.</param>
        public ShopCommand(IShopCommandConfig config, WorldModel worldModel)
        {
            _config = config;
            _worldModel = worldModel;
            _shopModel = new ShopModel(_config, _worldModel.ItemModelFactory);
        }

        /// <summary>
        /// ��ȣ�ۿ� ��� ����.
        /// </summary>
        /// <param name="interactionPlayer">��ȣ�ۿ� �÷��̾�.</param>
        /// <param name="processRunnable">�۾� ���� ������ ��ü.</param>
        /// <param name="interactor">��ȣ�ۿ� ���.</param>
        public void Execute(IInteractionPlayer interactionPlayer, IProcessRunnable processRunnable, IInteractor interactor)
        {
            // ��ȭ Ű�� ��ȿ���� ������ �������� ����.
            if (_config.ConversationKeys == null || _config.ConversationKeys.Count == 0) return;

            // �̹� ��ȭ ���̰ų� �ٸ� �۾��� ���� ���� ��� �������� ����.
            if (interactionPlayer.ConversationPlayer.IsPlaying == true
                || processRunnable.IsProcessRunnable == false) return;

            _conversationPlayer = interactionPlayer.ConversationPlayer;
            _inventoryController = interactionPlayer.InventoryController;
            _conversationPlayer.OnCompleted += OnConversationCompleted;

            // ���� ��ȭ ����.
            _conversationPlayer.StartConversation(_config.ConversationKeys.Choose());
            ProcessModel processModel = new ProcessModel(IProcessable.ProcessType.Idle, 0, null, OnProcessFailed);

            // �۾� ���� �� ���� �� ȣ���� �׼� ����.
            processRunnable.BeginProcessWithExternalControl(processModel, out _onRunnableEnded);
        }

        /// <summary>
        /// �۾� ���� �� ȣ��Ǵ� �޼���.
        /// </summary>
        void OnProcessFailed()
        {
            _conversationPlayer.StopConversation();
            _onRunnableEnded = null;
            _conversationPlayer = null;
            _inventoryController = null;
        }

        /// <summary>
        /// ��ȭ �Ϸ� �� ȣ��Ǵ� �޼���.
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

