using System.Collections;
using System.Collections.Generic;
using GamePlay.Factories;
using GamePlay.Modules;
using UnityEngine;

namespace GamePlay.Datas
{
    public class ShopModel : ModuleModelBase<IShopConfig>, IShopModel
    {
        IModelFactory<IItemModel, ItemData> _modelFactory;
        List<IItemModel> _itemModels = new List<IItemModel>();
        public IReadOnlyList<IItemModel> ItemModels => _itemModels;
        public ShopModel(IShopConfig config, IModelFactory<IItemModel, ItemData> modelFactory) : base(config)
        {
            _modelFactory = modelFactory;

            Initialize();
        }

        void Initialize()
        {
            foreach(string key in Config.ItemKeys)
            {
                ItemData itemData = new ItemData(key);
                IItemModel itemModel = _modelFactory.CreateModel(itemData);
                _itemModels.Add(itemModel);
            }

            _itemModels.Sort((a, b) => a.Config.Index.CompareTo(b.Config.Index));
        }
    }
}


