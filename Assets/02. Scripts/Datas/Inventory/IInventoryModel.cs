using GamePlay.Hubs.Equipments;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Datas
{
    public interface IInventoryModel
    {
        IInventoryConfig Config { get; }
        IReadOnlyList<IItemModel> ItemModels { get; }
        int Gold { get; }
        bool IsFull { get; }

        event Action OnChanged;
        event Action OnGoldChanged;
        event Action<IItemModel> OnItemAdded;
        event Action<IItemModel> OnItemRemoved;
        void AddItem(string key);
        bool TryGetItemModel(string key, out IItemModel itemModel);
        int GetItemModelCount(string key);
        int GetItemTypeCount(ItemType itemType);
        void RemoveItemType(ItemType itemType, int count);
        void UseItem(IItemModel itemModel);
        void DumpItem(IItemModel itemModel);
        void SellItem(IItemModel itemModel);
        void BuyItem(IItemModel itemModel);
    }
}


