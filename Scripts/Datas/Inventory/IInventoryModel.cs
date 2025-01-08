using System;
using System.Collections.Generic;

namespace GamePlay.Datas
{
    /// <summary>
    /// �κ��丮 ���� �����ϴ� �������̽��Դϴ�.
    /// </summary>
    public interface IInventoryModel
    {
        IInventoryConfig Config { get; }
        IReadOnlyList<IItemModel> ItemModels { get; }
        int Gold { get; }
        bool IsFull { get; }

        /// <summary>
        /// ������ ���� �� �߻��ϴ� �̺�Ʈ�Դϴ�.
        /// </summary>
        event Action OnChanged;

        /// <summary>
        /// ��� ���� �� �߻��ϴ� �̺�Ʈ�Դϴ�.
        /// </summary>
        event Action OnGoldChanged;

        /// <summary>
        /// �������� �߰��� �� �߻��ϴ� �̺�Ʈ�Դϴ�.
        /// </summary>
        event Action<IItemModel> OnItemAdded;

        /// <summary>
        /// �������� ���ŵ� �� �߻��ϴ� �̺�Ʈ�Դϴ�.
        /// </summary>
        event Action<IItemModel> OnItemRemoved;

        /// <summary>
        /// ������ Ű�� �������� �κ��丮�� �߰��մϴ�.
        /// </summary>
        /// <param name="key">�߰��� ������ Ű</param>
        void AddItem(string key);

        /// <summary>
        /// ������ Ű�� ������ ���� �˻��մϴ�.
        /// </summary>
        /// <param name="key">�˻��� ������ Ű</param>
        /// <param name="itemModel">�˻� ����� ��ȯ�� ������ ��</param>
        /// <returns>������ ���� �����ϸ� true</returns>
        bool TryGetItemModel(string key, out IItemModel itemModel);

        /// <summary>
        /// Ư�� Ű�� ������ ������ ��ȯ�մϴ�.
        /// </summary>
        /// <param name="key">�˻��� ������ Ű</param>
        /// <returns>�ش� Ű�� ������ ����</returns>
        int GetItemModelCount(string key);

        /// <summary>
        /// Ư�� ������ ������ ������ ��ȯ�մϴ�.
        /// </summary>
        /// <param name="itemType">�˻��� ������ ����</param>
        /// <returns>�ش� ������ ������ ����</returns>
        int GetItemTypeCount(ItemType itemType);

        /// <summary>
        /// ������ ���� Ư�� ���� �������� �����մϴ�.
        /// </summary>
        /// <param name="itemType">������ ������ ����</param>
        /// <param name="count">������ ����</param>
        void RemoveItemType(ItemType itemType, int count);

        /// <summary>
        /// �������� ����մϴ�.
        /// </summary>
        /// <param name="itemModel">����� ������ ��</param>
        void UseItem(IItemModel itemModel);

        /// <summary>
        /// �������� �����ϴ�.
        /// </summary>
        /// <param name="itemModel">���� ������ ��</param>
        void DumpItem(IItemModel itemModel);

        /// <summary>
        /// �������� �Ǹ��մϴ�.
        /// </summary>
        /// <param name="itemModel">�Ǹ��� ������ ��</param>
        void SellItem(IItemModel itemModel);

        /// <summary>
        /// �������� �����մϴ�.
        /// </summary>
        /// <param name="itemModel">������ ������ ��</param>
        void BuyItem(IItemModel itemModel);
    }
}


