using GamePlay.Modules;
using UnityEngine;

namespace GamePlay.Commands
{
    /// <summary>
    /// ��� ��� ���� Ŭ����.
    /// </summary>
    public class SansamCommand : IInteractionCommand
    {
        ISansamCommandConfig _config;
        WorldModel _worldModel;

        IInteractor _interactor;


        /// <summary>
        /// ������.
        /// </summary>
        /// <param name="config">��� ��� ����.</param>
        /// <param name="worldModel">���� �� ��ü.</param>
        public SansamCommand(ISansamCommandConfig config, WorldModel worldModel)
        {
            _config = config;
            _worldModel = worldModel;
        }

        /// <summary>
        /// ��� ��� ���� �޼���.
        /// </summary>
        public void Execute(IInteractionPlayer interactionPlayer, IProcessRunnable processRunnable, IInteractor interactor)
        {
            // �κ��丮�� ���� �� ���.
            if (_worldModel.InventoryModel.IsFull == true)
            {
                Debug.Log("�κ��丮�� ���� á���ϴ�.");
                return;
            }

            // �ٸ� �۾��� ���� ���� ���.
            if (processRunnable.IsProcessRunnable == false)
            {
                Debug.Log("�ٸ� �۾��� ���� ���Դϴ�.");
                return;
            }

            // ���μ��� �� ���� �� ����.
            ProcessModel processModel = new ProcessModel(_config.ProcessType, _config.ProcessAmount,
                OnProcessSuccess, OnProcessFailed);

            _interactor = interactor;
            processRunnable.BeginProcess(processModel);
        }


        /// <summary>
        /// �۾� ���� �� ȣ��˴ϴ�.
        /// </summary>
        void OnProcessFailed()
        {
            _interactor = null;
        }

        /// <summary>
        /// �۾� ���� �� ȣ��˴ϴ�.
        /// </summary>
        void OnProcessSuccess()
        {

            // ���� �� ������ �߰�.
            if (_worldModel.DifficultyModel.GetIsSansam())
                _worldModel.InventoryModel.AddItem(_config.SansamItemKey);
            else
                _worldModel.InventoryModel.AddItem(_config.NotSansamItemKey);
            _interactor.EndInteraction();

            _interactor = null;
        }
    }
}