using GamePlay.Configs;

namespace GamePlay.Hubs.Equipments
{
    /// <summary>
    /// 기어 모델 인터페이스.
    /// </summary>
    public interface IGearModel
    {
        GearConfig Config { get; }
    }
}
