using System;
using GamePlay.Configs;
using GamePlay.Datas;
using GamePlay.Modules;

namespace GamePlay.Commands
{
    /// <summary>
    /// �밨 ����� �����ϴ� Ŭ����.
    /// </summary>
    public class DaegamCommand : IInteractionCommand
    {
        IDaegamCommandConfig _config;
        WorldModel _worldModel;

        IConversationPlayer _conversationPlayer;
        IProcessRunnable _processRunnable;
        Action _onRunnableEnded;

        public DaegamCommand(IDaegamCommandConfig config, WorldModel worldModel)
        {
            _config = config;
            _worldModel = worldModel;
        }

        public void Execute(IInteractionPlayer interactionPlayer, IProcessRunnable processRunnable, IInteractor interactor)
        {
            if (interactionPlayer.ConversationPlayer.IsPlaying == true
                || processRunnable.IsProcessRunnable == false) return;

            _conversationPlayer = interactionPlayer.ConversationPlayer;
            _processRunnable = processRunnable;

            _conversationPlayer.OnCompleted += OnGreetingCompleted;

            // �밨�� ȯ�� ��ȭ ����.
            _conversationPlayer.StartConversation(_config.GreetingConversationKey);
            ProcessModel processModel = new ProcessModel(IProcessable.ProcessType.Idle, 0, null, OnProcessFailed);

            _processRunnable.BeginProcessWithExternalControl(processModel, out _onRunnableEnded);
        }

        void OnProcessFailed()
        {
            // ��ȭ ���� �� ó��.
            _conversationPlayer.StopConversation();
            _conversationPlayer = null;
            _onRunnableEnded = null;
            _processRunnable = null;
        }
        void OnGreetingCompleted()
        {
            // �λ� ��ȭ �Ϸ� �� ���� ��ȭ ����.
            _onRunnableEnded?.Invoke();
            _onRunnableEnded = null;
            _conversationPlayer.OnCompleted -= OnGreetingCompleted;

            string conversationKey = _config.ZeroConversationKey;
            int sansamCount = _worldModel.InventoryModel.GetItemTypeCount(ItemType.Sansam);
            int remainedSansamCount = _worldModel.StageModel.RemainedSansamCount;

            if (remainedSansamCount > 0 && sansamCount == 0)
                conversationKey = _config.ZeroConversationKey;
            else if (remainedSansamCount > 0 && sansamCount < remainedSansamCount)
            {
                conversationKey = _config.LackConversationKey;
                _worldModel.InventoryModel.RemoveItemType(ItemType.Sansam, sansamCount);
                _worldModel.StageModel.AddSubmitedSansamCount(sansamCount);
            }
            else
            {
                conversationKey = _config.ClearConversationKey;
                _worldModel.InventoryModel.RemoveItemType(ItemType.Sansam, remainedSansamCount);
                _worldModel.StageModel.AddSubmitedSansamCount(remainedSansamCount);
            }
                

            _conversationPlayer.OnCompleted += OnClearCheckCompleted;
            _conversationPlayer.StartConversation(conversationKey);

            ProcessModel processModel = new ProcessModel(IProcessable.ProcessType.Idle, 0,
                null, OnProcessFailed);
            _processRunnable.BeginProcessWithExternalControl(processModel, out _onRunnableEnded);
        }

        void OnClearCheckCompleted()
        {
            _onRunnableEnded?.Invoke();
            _onRunnableEnded = null;
            _processRunnable = null;
            _conversationPlayer.OnCompleted -= OnClearCheckCompleted;
            _conversationPlayer = null;

            // �������� Ŭ���� Ȯ�� �� ����
            if(_worldModel.StageModel.RemainedSansamCount <= 0)
            {
                _worldModel.TimeCycleModel.SetDateTimeByLevel(_worldModel.StageModel.Level);
                _worldModel.StageModel.AddLevel();
            }
        }
    }
}


