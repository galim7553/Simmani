using GamePlay.Datas;
using GamePlay.Views;
using UnityEngine;

namespace GamePlay.Presenters
{
    /// <summary>
    /// 인벤토리 아이템 정보를 표시하고, 아이템과의 인터랙션을 처리하는 프레젠터.
    /// </summary>
    public class ItemInfoPresenter : ResourceDependentPresenterBase<IInventoryModel, ItemInfoView>
    {
        InventoryMenuPresenter _inventoryMenuPresenter;
        IItemModel _itemModel;
        public ItemInfoPresenter(InventoryMenuPresenter inventoryMenuPresenter, IInventoryModel model, ItemInfoView view) : base(model, view)
        {
            _inventoryMenuPresenter = inventoryMenuPresenter;

            _view.Initialize();
            _model.OnItemRemoved += OnItemRemoved;
            _view.OnUseButtonClicked += OnUseButtonClicked;
            _view.OnDumpButtonClicked += OnDumpButtonClicked;
        }

        /// <summary>
        /// 아이템 정보를 표시합니다.
        /// </summary>
        /// <param name="itemModel">표시할 아이템의 모델.</param>
        public void DisaplyItemInfo(IItemModel itemModel)
        {
            _itemModel = itemModel;
            _itemModel.OnHasEquippedChanged += OnHasEquippedChanged;

            _view.gameObject.SetActive(true);
            _view.SetButtonActive(ItemInfoView.ButtonKey.DumpButton, _inventoryMenuPresenter.IsShopMode == false);
            _view.SetButtonActive(ItemInfoView.ButtonKey.UseButton,
                _inventoryMenuPresenter.IsShopMode == false && _itemModel.Config.IsUsable && _itemModel.Usage != null);

            OnHasEquippedChanged();

            _view.SetImage((int)ItemInfoView.ImageKey.ItemImage, GetResource<Sprite>(itemModel.Config.SpritePath));
            _view.SetTMP((int)ItemInfoView.TMPKey.ItemNameText, GetString(itemModel.Config.ItemNameKey));
            _view.SetTMP((int)ItemInfoView.TMPKey.ItemDescriptionText, GetString(itemModel.Config.DescriptionKey));
            _view.SetTMP((int)ItemInfoView.TMPKey.PriceText, itemModel.Config.Price.ToString());
        }

        /// <summary>
        /// 아이템 장착 여부 변경 시 호출됩니다.
        /// </summary>
        void OnHasEquippedChanged()
        {
            if(_itemModel == null || _inventoryMenuPresenter.IsShopMode == true) return;

            if (_itemModel.HasEquipped == true)
                _view.SetTMP((int)ItemInfoView.TMPKey.UseButtonText, GetString(_model.Config.UnuseButtonTextKey));
            else
                _view.SetTMP((int)ItemInfoView.TMPKey.UseButtonText, GetString(_model.Config.UseButtonTextKey));
            _view.SetTMP((int)ItemInfoView.TMPKey.DumpButtonText, GetString(_model.Config.DumpButtonTextKey));
        }

        /// <summary>
        /// 아이템 정보를 표시하지 않도록 설정합니다.
        /// </summary>
        public void UndisplayItemInfo()
        {
            if(_itemModel != null)
                _itemModel.OnHasEquippedChanged -= OnHasEquippedChanged;
            _itemModel = null;

            _view.gameObject.SetActive(false);
        }


        /// <summary>
        /// "사용" 버튼 클릭 시 호출됩니다.
        /// </summary>
        void OnUseButtonClicked()
        {
            if (_itemModel != null)
                _model.UseItem(_itemModel);
        }

        /// <summary>
        /// "버리기" 버튼 클릭 시 호출됩니다.
        /// </summary>
        void OnDumpButtonClicked()
        {
            if(_itemModel != null)
            {
                _model.DumpItem(_itemModel);
                UndisplayItemInfo();
            }
        }

        /// <summary>
        /// 아이템이 제거되었을 때 호출됩니다.
        /// </summary>
        void OnItemRemoved(IItemModel itemModel)
        {
            if (_itemModel == itemModel)
                UndisplayItemInfo();
        }

        public override void Clear()
        {
            base.Clear();

            _view.Clear();
            if (_itemModel != null)
                _itemModel.OnHasEquippedChanged -= OnHasEquippedChanged;
        }
    }
}


