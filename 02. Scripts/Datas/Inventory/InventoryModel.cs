using System;
using System.Collections.Generic;
using System.Linq;
using GamePlay.Factories;
using GamePlay.Hubs.Equipments;
using GamePlay.Hubs;
using GamePlay.Modules;
using UnityEngine;
using GamePlay.Commands;

namespace GamePlay.Datas
{
    /// <summary>
    /// 인벤토리 모델을 관리하는 클래스입니다.
    /// </summary>
    public class InventoryModel : DataDependantModelBase<IInventoryConfig, InventoryData>, IInventoryModel
    {
        // ----- Fields ----- //
        IModelFactory<IItemModel, ItemData> _modelFactory;
        List<IItemModel> _itemModels = new List<IItemModel>();

        HeroModel _heroModel;
        IEquipperModel _equipperModel;
        // ----- Fields ----- //

        // ----- Properties ----- //
        public IReadOnlyList<IItemModel> ItemModels => _itemModels;
        public int Gold => _data.Gold;
        public bool IsFull => _data.ItemDatas.Count >= Config.SlotLimit;
        // ----- Properties ----- //

        // ----- Events ----- //
        public event Action OnChanged;
        public event Action OnGoldChanged;
        public event Action<IItemModel> OnItemAdded;
        public event Action<IItemModel> OnItemRemoved;
        // ----- Events ----- //

        /// <summary>
        /// 생성자: 인벤토리 모델을 초기화합니다.
        /// </summary>
        public InventoryModel(IInventoryConfig config, InventoryData data, HeroModel heroModel, IModelFactory<IItemModel, ItemData> modelFactory) : base(config, data)
        {
            _modelFactory = modelFactory;
            _heroModel = heroModel;
            _equipperModel = _heroModel.EquipperModel;

            // 기존 데이터에서 아이템을 초기화
            for (int i = 0; i < Mathf.Min(_data.ItemDatas.Count, Config.SlotLimit); i++)
                AddItemModel(_data.ItemDatas[i]);

            SortItemModels();
        }

        public void AddItem(string key)
        {
            if (IsFull) return;

            ItemData itemData = new ItemData(key);
            _data.AddItemData(itemData);

            AddItemModel(itemData);

            SortItemModels();

            OnChanged?.Invoke();
        }
        void RemoveItem(IItemModel itemModel)
        {
            _itemModels.Remove(itemModel);
            _data.RemoveItemData(itemModel.Data);

            SortItemModels();

            OnChanged?.Invoke();
            OnItemRemoved?.Invoke(itemModel);
        }
        void AddItemModel(ItemData itemData)
        {
            IItemModel itemModel = _modelFactory.CreateModel(itemData);
            _itemModels.Add(itemModel);

            if (itemModel.Config.ItemType == ItemType.Passive && itemModel.Usage is IHeroModelCommand command)
                command.Apply(_heroModel);


            OnItemAdded?.Invoke(itemModel);
        }
        void SortItemModels()
        {
            _itemModels.Sort((a, b) => a.Config.Index.CompareTo(b.Config.Index));
        }

        public bool TryGetItemModel(string key, out IItemModel itemModel)
        {
            itemModel = _itemModels.Find(a => a.Config.Key == key);
            if (itemModel == null)
                return false;
            return true;
        }

        public int GetItemModelCount(string key)
        {
            int count = _itemModels.Count(a => a.Config.Key == key);
            return count;
        }
        public int GetItemTypeCount(ItemType itemType)
        {
            int count = _itemModels.Count(a => a.Config.ItemType == itemType);
            return count;
        }


        public void UseItem(IItemModel itemModel)
        {
            IItemUsage usage = itemModel.Usage;
            if (usage == null) return;

            switch (usage)
            {
                case IEquipmentModel equipmentModel:
                    // 이전에 장착한 장비가 현재 장비와 동일한 경우에는 해제한다.
                    if (_equipperModel.EquipmentModelMap.TryGetValue(equipmentModel.Config.EquipSlot, out var prev)
                        && prev == equipmentModel)
                        _equipperModel.Unequip(prev.Config.EquipSlot);

                    // 이전에 장착한 장비가 없거나, 있어도 현재 장비와 다른 경우에는 장착한다.
                    else
                        _equipperModel.TryEquip(equipmentModel);
                    break;
                case IHeroModelCommand command when itemModel.Config.ItemType == ItemType.Consumable:
                    command.Apply(_heroModel);
                    if (itemModel.Config.ItemType == ItemType.Consumable)
                        DumpItem(itemModel);
                    break;
            }
        }
        public void DumpItem(IItemModel itemModel)
        {
            IItemUsage usage = itemModel.Usage;
            if (usage != null)
            {
                switch (usage)
                {
                    case IEquipmentModel equipmentModel:
                        // 이전에 장착한 장비가 현재 장비와 동일한 경우에는 해제한다.
                        if (_equipperModel.EquipmentModelMap.TryGetValue(equipmentModel.Config.EquipSlot, out var prev)
                            && prev == equipmentModel)
                            _equipperModel.Unequip(prev.Config.EquipSlot);
                        break;
                    case IHeroModelCommand command when itemModel.Config.ItemType == ItemType.Passive:
                        command.Disapply(_heroModel);
                        break;

                }
            }
            RemoveItem(itemModel);
        }

        public void RemoveItemType(ItemType itemType, int count)
        {
            if (count <= 0) return;

            List<IItemModel> itemModels = _itemModels.FindAll(a => a.Config.ItemType == itemType);
            for (int i = 0; i < Mathf.Min(itemModels.Count, count); i++)
            {
                DumpItem(itemModels[i]);
            }
        }

        public void SellItem(IItemModel model)
        {
            DumpItem(model);
            AddGold(model.Config.Price);
        }

        void AddGold(int gold)
        {
            gold = Mathf.Max(-Gold, gold);
            _data.AddGold(gold);
            OnGoldChanged?.Invoke();
        }

        public void BuyItem(IItemModel model)
        {
            if (IsFull == true) return;
            if (Gold < model.Config.Price) return;

            AddGold(-model.Config.Price);
            AddItem(model.Config.Key);
        }
    }
}