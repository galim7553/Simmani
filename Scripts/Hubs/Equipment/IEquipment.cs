using UnityEngine;

namespace GamePlay.Hubs.Equipments
{
    /// <summary>
    /// 장비의 유형을 정의하는 열거형.
    /// </summary>
    public enum EquipType
    {
        Gear,
        Weapon,
    }

    /// <summary>
    /// 장비가 장착될 슬롯을 정의하는 열거형.
    /// </summary>
    public enum EquipSlot
    {
        None,
        RightHand,
        LeftHand,
    }

    /// <summary>
    /// 장비의 동작을 정의하는 인터페이스.
    /// </summary>
    public interface IEquipment
    {

        /// <summary>
        /// 장비를 장착합니다.
        /// </summary>
        /// <param name="parent">장착될 부모 트랜스폼</param>
        void Equip(Transform parent);

        /// <summary>
        /// 장비를 해제합니다.
        /// </summary>
        void Unequip();

        /// <summary>
        /// 장비의 유형.
        /// </summary>
        EquipType EquipType { get; }
    }
}