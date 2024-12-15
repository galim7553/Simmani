using System;
using System.Collections;
using System.Collections.Generic;
using GamePlay.Datas;
using GamePlay.Modules;
using GamePlay.Scene;
using UnityEngine;

namespace GamePlay.Commands
{
    public class ShopCommand : IInteractionCommand
    {
        IShopCommandConfig _config;
        WorldModel _worldModel;
        ShopModel _shopModel;

        IConversationPlayer _conversationPlayer;
        IInventoryController _inventoryController;
        Action _onRunnableEnded;

        public ShopCommand(IShopCommandConfig config, WorldModel worldModel)
        {
            _config = config;
            _worldModel = worldModel;
            _shopModel = new ShopModel(_config, _worldModel.ItemModelFactory);
        }

        public void Execute(IInteractionPlayer interactionPlayer, IProcessRunnable processRunnable, IInteractor interactor)
        {
            if (_config.ConversationKeys == null || _config.ConversationKeys.Count == 0) return;

            if (interactionPlayer.ConversationPlayer.IsPlaying == true
                || processRunnable.IsProcessRunnable == false) return;

            _conversationPlayer = interactionPlayer.ConversationPlayer;
            _inventoryController = interactionPlayer.InventoryController;
            _conversationPlayer.OnCompleted += OnConversationCompleted;

            _conversationPlayer.StartConversation(_config.ConversationKeys.Choose());
            ProcessModel processModel = new ProcessModel(IProcessable.ProcessType.Idle, 0, null, OnProcessFailed);

            processRunnable.BeginProcessWithExternalControl(processModel, out _onRunnableEnded);
        }

        void OnProcessFailed()
        {
            _conversationPlayer.StopConversation();
            _onRunnableEnded = null;
            _conversationPlayer = null;
            _inventoryController = null;
        }
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

