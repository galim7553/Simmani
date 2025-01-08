using GamePlay.Commands;

namespace GamePlay.Modules
{
    /// <summary>
    /// ��ȣ�ۿ���(Interactor) ���� �⺻ ���� Ŭ����.
    /// </summary>
    public class InteractorModel : ModuleModelBase<IInteractorConfig>, IInteractorModel
    {
        public ICommand Command { get; private set; }


        /// <summary>
        /// InteractorModel ������.
        /// </summary>
        /// <param name="config">Interactor ����.</param>
        /// <param name="command">Interactor�� ����� ���.</param>
        public InteractorModel(IInteractorConfig config, ICommand command) : base(config)
        {
            Command = command;
        }
    }
}


