using System.Collections.Generic;
using GamePlay.Factories;
using GamePlay.Modules;

namespace GamePlay.Datas
{
    /// <summary>
    /// 상점 모델 클래스입니다. 설정 및 아이템 데이터를 기반으로 상점을 초기화합니다.
    /// </summary>
    public class ShopModel : ModuleModelBase<IShopConfig>, IShopModel
    {
        IModelFactory<IItemModel, ItemData> _modelFactory;
        List<IItemModel> _itemModels = new List<IItemModel>();
        public IReadOnlyList<IItemModel> ItemModels => _itemModels;

        /// <summary>
        /// ShopModel 생성자입니다.
        /// </summary>
        /// <param name="config">상점 설정 객체</param>
        /// <param name="modelFactory">아이템 모델을 생성하는 팩토리</param>
        public ShopModel(IShopConfig config, IModelFactory<IItemModel, ItemData> modelFactory) : base(config)
        {
            _modelFactory = modelFactory;

            Initialize();
        }

        /// <summary>
        /// 상점을 초기화하고 아이템 모델을 생성합니다.
        /// </summary>
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


