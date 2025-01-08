using UnityEngine;

namespace GamePlay.Hubs.Equipments
{
    /// <summary>
    /// ����� ������ �����ϴ� ������.
    /// </summary>
    public enum EquipType
    {
        Gear,
        Weapon,
    }

    /// <summary>
    /// ��� ������ ������ �����ϴ� ������.
    /// </summary>
    public enum EquipSlot
    {
        None,
        RightHand,
        LeftHand,
    }

    /// <summary>
    /// ����� ������ �����ϴ� �������̽�.
    /// </summary>
    public interface IEquipment
    {

        /// <summary>
        /// ��� �����մϴ�.
        /// </summary>
        /// <param name="parent">������ �θ� Ʈ������</param>
        void Equip(Transform parent);

        /// <summary>
        /// ��� �����մϴ�.
        /// </summary>
        void Unequip();

        /// <summary>
        /// ����� ����.
        /// </summary>
        EquipType EquipType { get; }
    }
}