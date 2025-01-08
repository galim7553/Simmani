using GamePlay.Commands;

namespace GamePlay.Modules
{
    /// <summary>
    /// 상호작용자(Interactor)의 데이터 모델 인터페이스.
    /// </summary>
    public interface IInteractorModel
    {
        /// <summary>현재 상호작용 명령을 나타냄.</summary>
        ICommand Command { get; }
    }
}