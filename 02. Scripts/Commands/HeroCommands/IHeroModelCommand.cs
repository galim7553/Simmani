using GamePlay.Datas;

namespace GamePlay.Commands
{
    /// <summary>
    /// Hero 모델에서 실행 가능한 명령 인터페이스.
    /// </summary>
    public interface IHeroModelCommand : IAppliableCommand<IHeroModel>, IItemUsage
    {

    }
}