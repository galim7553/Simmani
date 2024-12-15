using System.Collections;
using System.Collections.Generic;
using GamePlay.Datas;
using GamePlay.Views;
using UnityEngine;

namespace GamePlay.Presenters
{
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

        void OnHasEquippedChanged()
        {
            if(_itemModel == null || _inventoryMenuPresenter.IsShopMode == true) return;

            if (_itemModel.HasEquipped == true)
                _view.SetTMP((int)ItemInfoView.TMPKey.UseButtonText, GetString(_model.Config.UnuseButtonTextKey));
            else
                _view.SetTMP((int)ItemInfoView.TMPKey.UseButtonText, GetString(_model.Config.UseButtonTextKey));
            _view.SetTMP((int)ItemInfoView.TMPKey.DumpButtonText, GetString(_model.Config.DumpButtonTextKey));
        }

        public void UndisplayItemInfo()
        {
            if(_itemModel != null)
                _itemModel.OnHasEquippedChanged -= OnHasEquippedChanged;
            _itemModel = null;

            _view.gameObject.SetActive(false);
        }

        void OnUseButtonClicked()
        {
            if (_itemModel != null)
                _model.UseItem(_itemModel);
        }
        void OnDumpButtonClicked()
        {
            if(_itemModel != null)
            {
                _model.DumpItem(_itemModel);
                UndisplayItemInfo();
            }
        }
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


