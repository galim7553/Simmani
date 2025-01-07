using System;
using System.Collections.Generic;
using GamePlay.Hubs.Equipments;

namespace GamePlay.Modules
{
    /// <summary>
    /// 장비 장착 데이터를 관리하는 인터페이스.
    /// </summary>
    public interface IEquipperModel
    {
        /// <summary>
        /// 설정값 참조.
        /// </summary>
        IEquipperConfig Config { get; }

        /// <summary>
        /// 장비 장착 이벤트.
        /// </summary>
        event Action<EquipSlot, IEquipmentModel> OnEquipped;

        /// <summary>
        /// 장비 해제 이벤트.
        /// </summary>
        event Action<EquipSlot, IEquipmentModel> OnUnequipped;

        /// <summary>
        /// 장착된 장비 모델 맵.
        /// </summary>
        IReadOnlyDictionary<EquipSlot, IEquipmentModel> EquipmentModelMap { get; }

        /// <summary>
        /// 장비를 장착합니다.
        /// </summary>
        bool TryEquip(IEquipmentModel model);

        /// <summary>
        /// 특정 슬롯의 장비를 해제합니다.
        /// </summary>
        void Unequip(EquipSlot slot);
    }
}