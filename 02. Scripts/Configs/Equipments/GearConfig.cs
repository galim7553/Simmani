using GamePlay.Hubs.Equipments;
using System;

namespace GamePlay.Configs
{
    /// <summary>
    /// 기어(Gear) 설정값을 정의하는 클래스.
    /// </summary>
    [Serializable]
    public class GearConfig : EquipmentConfig
    {
        public override EquipType EquipType => EquipType.Gear;
    }
}


