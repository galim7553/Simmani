using System;
using System.Collections.Generic;
using GamePlay.Hubs.Equipments;

namespace GamePlay.Modules
{
    /// <summary>
    /// ��� ���� �����͸� �����ϴ� �������̽�.
    /// </summary>
    public interface IEquipperModel
    {
        /// <summary>
        /// ������ ����.
        /// </summary>
        IEquipperConfig Config { get; }

        /// <summary>
        /// ��� ���� �̺�Ʈ.
        /// </summary>
        event Action<EquipSlot, IEquipmentModel> OnEquipped;

        /// <summary>
        /// ��� ���� �̺�Ʈ.
        /// </summary>
        event Action<EquipSlot, IEquipmentModel> OnUnequipped;

        /// <summary>
        /// ������ ��� �� ��.
        /// </summary>
        IReadOnlyDictionary<EquipSlot, IEquipmentModel> EquipmentModelMap { get; }

        /// <summary>
        /// ��� �����մϴ�.
        /// </summary>
        bool TryEquip(IEquipmentModel model);

        /// <summary>
        /// Ư�� ������ ��� �����մϴ�.
        /// </summary>
        void Unequip(EquipSlot slot);
    }
}