using System;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Datas
{
    /// <summary>
    /// �κ��丮 �����͸� �����ϴ� Ŭ�����Դϴ�.
    /// </summary>
    [Serializable]
    public class InventoryData
    {
        [SerializeField] List<ItemData> _itemDatas = new List<ItemData>();
        [SerializeField] int _gold = 0;
        public IReadOnlyList<ItemData> ItemDatas => _itemDatas;
        public int Gold => _gold;

        /// <summary>
        /// ������ �����͸� �κ��丮�� �߰��մϴ�.
        /// </summary>
        /// <param name="itemData">�߰��� ������ ������</param>
        public void AddItemData(ItemData itemData)
        {
            _itemDatas.Add(itemData);
        }

        /// <summary>
        /// ������ �����͸� �κ��丮���� �����մϴ�.
        /// </summary>
        /// <param name="itemData">������ ������ ������</param>
        public void RemoveItemData(ItemData itemData)
        {
            _itemDatas.Remove(itemData);
        }

        /// <summary>
        /// ��带 �߰��մϴ�.
        /// </summary>
        /// <param name="gold">�߰��� ��� ��</param>
        public void AddGold(int gold)
        {
            _gold += gold;
        }
    }
}