using GamePlay.Datas;
using GamePlay.Modules;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Commands
{
    public class SansamCommand : IInteractionCommand
    {
        ISansamCommandConfig _config;
        WorldModel _worldModel;

        IInteractor _interactor;

        public SansamCommand(ISansamCommandConfig config, WorldModel worldModel)
        {
            _config = config;
            _worldModel = worldModel;
        }

        public void Execute(IInteractionPlayer interactionPlayer, IProcessRunnable processRunnable, IInteractor interactor)
        {
            if(_worldModel.InventoryModel.IsFull == true)
            {
                Debug.Log("�κ��丮�� ���� á���ϴ�.");
                return;
            }
            if(processRunnable.IsProcessRunnable == false)
            {
                Debug.Log("�ٸ� �۾��� ���� ���Դϴ�.");
                return;
            }

            ProcessModel processModel = new ProcessModel(_config.ProcessType, _config.ProcessAmount,
                OnProcessSuccess, OnProcessFailed);

            _interactor = interactor;
            processRunnable.BeginProcess(processModel);
        }

        void OnProcessFailed()
        {
            _interactor = null;
        }
        void OnProcessSuccess()
        {
            if (_worldModel.DifficultyModel.GetIsSansam())
                _worldModel.InventoryModel.AddItem(_config.SansamItemKey);
            else
                _worldModel.InventoryModel.AddItem(_config.NotSansamItemKey);
            _interactor.EndInteraction();

            _interactor = null;
        }
    }
}