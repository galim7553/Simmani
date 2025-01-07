using System;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Datas
{
    /// <summary>
    /// 인벤토리 데이터를 관리하는 클래스입니다.
    /// </summary>
    [Serializable]
    public class InventoryData
    {
        [SerializeField] List<ItemData> _itemDatas = new List<ItemData>();
        [SerializeField] int _gold = 0;
        public IReadOnlyList<ItemData> ItemDatas => _itemDatas;
        public int Gold => _gold;

        /// <summary>
        /// 아이템 데이터를 인벤토리에 추가합니다.
        /// </summary>
        /// <param name="itemData">추가할 아이템 데이터</param>
        public void AddItemData(ItemData itemData)
        {
            _itemDatas.Add(itemData);
        }

        /// <summary>
        /// 아이템 데이터를 인벤토리에서 제거합니다.
        /// </summary>
        /// <param name="itemData">제거할 아이템 데이터</param>
        public void RemoveItemData(ItemData itemData)
        {
            _itemDatas.Remove(itemData);
        }

        /// <summary>
        /// 골드를 추가합니다.
        /// </summary>
        /// <param name="gold">추가할 골드 양</param>
        public void AddGold(int gold)
        {
            _gold += gold;
        }
    }
}