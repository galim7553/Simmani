using GamePlay.Commands;

namespace GamePlay.Modules
{
    /// <summary>
    /// 상호작용자(Interactor) 모델의 기본 구현 클래스.
    /// </summary>
    public class InteractorModel : ModuleModelBase<IInteractorConfig>, IInteractorModel
    {
        public ICommand Command { get; private set; }


        /// <summary>
        /// InteractorModel 생성자.
        /// </summary>
        /// <param name="config">Interactor 설정.</param>
        /// <param name="command">Interactor가 사용할 명령.</param>
        public InteractorModel(IInteractorConfig config, ICommand command) : base(config)
        {
            Command = command;
        }
    }
}


