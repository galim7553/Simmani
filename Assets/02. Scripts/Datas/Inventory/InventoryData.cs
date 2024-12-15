using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Datas
{
    [Serializable]
    public class InventoryData
    {
        [SerializeField] List<ItemData> _itemDatas = new List<ItemData>();
        [SerializeField] int _gold = 0;
        public IReadOnlyList<ItemData> ItemDatas => _itemDatas;
        public int Gold => _gold;

        public void AddItemData(ItemData itemData)
        {
            _itemDatas.Add(itemData);
        }
        public void RemoveItemData(ItemData itemData)
        {
            _itemDatas.Remove(itemData);
        }
        public void AddGold(int gold)
        {
            _gold += gold;
        }
    }
}