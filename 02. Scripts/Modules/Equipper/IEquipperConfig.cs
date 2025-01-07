using GamePlay.Hubs.Equipments;
using System.Collections.Generic;

namespace GamePlay.Modules
{
    /// <summary>
    /// ��� ���� �������� �����ϴ� �������̽�.
    /// </summary>
    public interface IEquipperConfig
    {
        /// <summary>
        /// ĳ���Ͱ� ���� ������ ���� ���.
        /// </summary>
        IEnumerable<EquipSlot> EquipSlots { get; }
    }
}
