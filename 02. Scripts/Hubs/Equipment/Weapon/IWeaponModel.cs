using GamePlay.Configs;

namespace GamePlay.Hubs.Equipments
{
    /// <summary>
    /// 무기 모델 인터페이스. 무기 설정값을 제공.
    /// </summary>
    public interface IWeaponModel
    {
        WeaponConfig Config { get; }
    }
}

