using GamePlay.Hubs.Equipments;
using System;

namespace GamePlay.Configs
{
    /// <summary>
    /// ���(Gear) �������� �����ϴ� Ŭ����.
    /// </summary>
    [Serializable]
    public class GearConfig : EquipmentConfig
    {
        public override EquipType EquipType => EquipType.Gear;
    }
}


