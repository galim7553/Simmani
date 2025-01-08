using GamePlay.Modules;
using UnityEngine;

namespace GamePlay.Commands
{
    /// <summary>
    /// 산삼 명령 구현 클래스.
    /// </summary>
    public class SansamCommand : IInteractionCommand
    {
        ISansamCommandConfig _config;
        WorldModel _worldModel;

        IInteractor _interactor;


        /// <summary>
        /// 생성자.
        /// </summary>
        /// <param name="config">산삼 명령 설정.</param>
        /// <param name="worldModel">월드 모델 객체.</param>
        public SansamCommand(ISansamCommandConfig config, WorldModel worldModel)
        {
            _config = config;
            _worldModel = worldModel;
        }

        /// <summary>
        /// 산삼 명령 실행 메서드.
        /// </summary>
        public void Execute(IInteractionPlayer interactionPlayer, IProcessRunnable processRunnable, IInteractor interactor)
        {
            // 인벤토리가 가득 찬 경우.
            if (_worldModel.InventoryModel.IsFull == true)
            {
                Debug.Log("인벤토리가 가득 찼습니다.");
                return;
            }

            // 다른 작업이 진행 중인 경우.
            if (processRunnable.IsProcessRunnable == false)
            {
                Debug.Log("다른 작업이 진행 중입니다.");
                return;
            }

            // 프로세스 모델 생성 및 실행.
            ProcessModel processModel = new ProcessModel(_config.ProcessType, _config.ProcessAmount,
                OnProcessSuccess, OnProcessFailed);

            _interactor = interactor;
            processRunnable.BeginProcess(processModel);
        }


        /// <summary>
        /// 작업 실패 시 호출됩니다.
        /// </summary>
        void OnProcessFailed()
        {
            _interactor = null;
        }

        /// <summary>
        /// 작업 성공 시 호출됩니다.
        /// </summary>
        void OnProcessSuccess()
        {

            // 성공 시 아이템 추가.
            if (_worldModel.DifficultyModel.GetIsSansam())
                _worldModel.InventoryModel.AddItem(_config.SansamItemKey);
            else
                _worldModel.InventoryModel.AddItem(_config.NotSansamItemKey);
            _interactor.EndInteraction();

            _interactor = null;
        }
    }
}