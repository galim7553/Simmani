using GamePlay.Hubs.Equipments;
using System.Collections.Generic;

namespace GamePlay.Modules
{
    /// <summary>
    /// 장비 장착 설정값을 정의하는 인터페이스.
    /// </summary>
    public interface IEquipperConfig
    {
        /// <summary>
        /// 캐릭터가 장착 가능한 슬롯 목록.
        /// </summary>
        IEnumerable<EquipSlot> EquipSlots { get; }
    }
}
