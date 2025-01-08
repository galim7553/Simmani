using System;

namespace GamePlay.Datas
{
    public enum ItemType
    {
        Sansam,
        Sellable,
        Equipment,
        Consumable,
        Passive,
    }

    /// <summary>
    /// ������ �� �������̽��Դϴ�.
    /// </summary>
    public interface IItemModel
    {
        ItemData Data { get; }

        /// <summary>
        /// �������� ���� �����Դϴ�.
        /// </summary>
        bool HasEquipped { get; }
        IItemConfig Config { get; }

        /// <summary>
        /// ������ ��� ���� ���� ��ü�Դϴ�.
        /// </summary>
        IItemUsage Usage { get; }

        /// <summary>
        /// ������ ���� ���� ���� �̺�Ʈ�Դϴ�.
        /// </summary>
        event Action OnHasEquippedChanged;
    }

}

