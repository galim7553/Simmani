using System.Collections.Generic;
using GamePlay.Datas;
using GamePlay.Factories;
using GamePlay.Views;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GamePlay.Presenters
{
    public class InventoryMenuPresenter : ResourceDependentPresenterBase<IInventoryModel, InventoryMenuView>
    {
        ViewFactory _viewFactory;
        List<ItemOnInventoryPresenter> _itemOnInventoryPresenters = new List<ItemOnInventoryPresenter>();

        IShopModel _shopModel;
        List<ItemOnInventoryPresenter> _itemOnShopPresenters = new List<ItemOnInventoryPresenter>();

        ItemInfoPresenter _itemInfoPresenter;

        public bool IsVisible { get; private set; } = false;
        public bool IsShopMode => _shopModel != null;

        public InventoryMenuPresenter(IInventoryModel model, InventoryMenuView view, ViewFactory viewFactory) : base(model, view)
        {
            _viewFactory = viewFactory;
            Initialize();
        }

        void Initialize()
        {
            _view.Initialize();

            _itemInfoPresenter = new ItemInfoPresenter(this, _model, _view.GetItemInfoView(InventoryMenuView.ItemInfoViewKey.ItemInfoView));
        }

        public void DisplayInventoryMenu(bool isVisible, IShopModel shopModel = null)
        {
            IsVisible = isVisible;
            _model.OnChanged -= OnChanged;
            _model.OnGoldChanged -= OnGoldChanged;
            _shopModel = null;

            if (IsVisible)
            {
                _model.OnChanged += OnChanged;
                _model.OnGoldChanged += OnGoldChanged;

                CreateItemOnInventories();
                UpdateGold();
                UpdateBagInfo();
                OnItemUnfocused();
                SetShopModel(shopModel);
            }
            _view.gameObject.SetActive(IsVisible);
        }


        void SetShopModel(IShopModel shopModel)
        {
            _shopModel = shopModel;
            CreateItemOnShops();
            SetInventoryItemDraggable(IsShopMode);
            _view.SetComponentActive(InventoryMenuView.TransformKey.ShopPanel, IsShopMode);
            UpdateShopName();
        }

        void ClearItemOnInventories()
        {
            foreach (var ioiPrst in _itemOnInventoryPresenters)
                ioiPrst.Clear();
            _itemOnInventoryPresenters.Clear();
        }
        void CreateItemOnInventories()
        {
            ClearItemOnInventories();
            foreach (var itemModel in _model.ItemModels)
                CreateItemOnInventory(itemModel);
        }

        void CreateItemOnInventory(IItemModel itemModel)
        {
            ItemOnInventoryView view = _viewFactory.CreateView<ItemOnInventoryView>(_model.Config.ItemOnInventoryViewPrefabPath);
            _view.AddItemOnInventoryView(view);

            ItemOnInventoryPresenter presenter = new ItemOnInventoryPresenter(itemModel, view);
            presenter.OnItemFocused += OnItemFocused;
            presenter.OnItemDragBegun += OnInventoryItemDragBegun;
            presenter.OnItemDropped += OnInventoryItemDropped;
            presenter.SetIsDraggable(IsShopMode);
            _itemOnInventoryPresenters.Add(presenter);
        }

        void ClearItemOnShops()
        {
            foreach (var ioiPrst in _itemOnShopPresenters)
                ioiPrst.Clear();
            _itemOnShopPresenters.Clear();
        }
        void CreateItemOnShops()
        {
            ClearItemOnShops();
            if (_shopModel == null) return;
            foreach (var itemModel in _shopModel.ItemModels)
                CreateItemOnShops(itemModel);
        }
        void CreateItemOnShops(IItemModel itemModel)
        {
            ItemOnInventoryView view = _viewFactory.CreateView<ItemOnInventoryView>(_model.Config.ItemOnInventoryViewPrefabPath);
            _view.AddItemOnShopView(view);

            ItemOnInventoryPresenter presenter = new ItemOnInventoryPresenter(itemModel, view);
            presenter.OnItemFocused += OnItemFocused;
            presenter.OnItemDragBegun += OnShopItemDragBegun;
            presenter.OnItemDropped += OnShopItemDropped;
            presenter.SetIsDraggable(IsShopMode);
            _itemOnShopPresenters.Add(presenter);
        }

        void UpdateGold()
        {
            _view.SetTMP((int)InventoryMenuView.TMPKey.GoldText, _model.Gold.ToString());
        }
        void UpdateBagInfo()
        {
            _view.SetTMP((int)InventoryMenuView.TMPKey.BagInfoText,
                $"{_model.ItemModels.Count} / {_model.Config.SlotLimit}");
        }
        void UpdateShopName()
        {
            if (_shopModel == null) return;
            _view.SetTMP((int)InventoryMenuView.TMPKey.ShopTitleText, GetString(_shopModel.Config.ShopNameKey));
        }
        void SetInventoryItemDraggable(bool isDraggable)
        {
            foreach(var ioip in _itemOnInventoryPresenters)
                ioip.SetIsDraggable(isDraggable);
        }


        void OnChanged()
        {
            CreateItemOnInventories();
            UpdateBagInfo();
        }
        void OnGoldChanged()
        {
            UpdateGold();
        }
        void OnItemFocused(ItemOnInventoryPresenter ioip)
        {
            foreach (var presenter in _itemOnInventoryPresenters)
                presenter.SetIsFocused(false);
            foreach(var presenter in _itemOnShopPresenters)
                presenter.SetIsFocused(false);
            ioip.SetIsFocused(true);
            _itemInfoPresenter.DisaplyItemInfo(ioip.Model);
        }
        void OnItemUnfocused()
        {
            foreach (var presenter in _itemOnInventoryPresenters)
                presenter.SetIsFocused(false);
            foreach (var presenter in _itemOnShopPresenters)
                presenter.SetIsFocused(false);
            _itemInfoPresenter.UndisplayItemInfo();
        }

        void OnInventoryItemDragBegun(IItemModel itemModel)
        {
            _view.SetTMP((int)InventoryMenuView.TMPKey.SellGuideText, GetString(_model.Config.SellGuideTextKey));
            _view.SetComponentActive(InventoryMenuView.TransformKey.SellGuidePanel, true);
        }
        void OnInventoryItemDropped(IItemModel itemModel, List<RaycastResult> results)
        {
            OnItemUnfocused();
            _view.SetComponentActive(InventoryMenuView.TransformKey.SellGuidePanel, false);
            Transform shopPanel = _view.GetTransform(InventoryMenuView.TransformKey.ShopPanel);
            foreach(var result in results)
            {
                if (shopPanel == result.gameObject.transform)
                {
                    _model.SellItem(itemModel);
                    break;
                }
            }
        }

        void OnShopItemDragBegun(IItemModel itemModel)
        {
            if (_model.IsFull == true)
                _view.SetTMP((int)InventoryMenuView.TMPKey.BuyGuideText, GetString(_model.Config.NotEnoughtSlotTextKey));
            else if (_model.Gold < itemModel.Config.Price)
                _view.SetTMP((int)InventoryMenuView.TMPKey.BuyGuideText, GetString(_model.Config.NotEnoughGoldTextKey));
            else
                _view.SetTMP((int)InventoryMenuView.TMPKey.BuyGuideText, GetString(_model.Config.BuyGuideTextKey));
            _view.SetComponentActive(InventoryMenuView.TransformKey.BuyGuidePanel, true);
        }
        void OnShopItemDropped(IItemModel itemModel, List<RaycastResult> results)
        {
            OnItemUnfocused();
            _view.SetComponentActive(InventoryMenuView.TransformKey.BuyGuidePanel, false);
            Transform inventoryPanel = _view.GetTransform(InventoryMenuView.TransformKey.InventoryPanel);
            foreach (var result in results)
            {
                if (inventoryPanel == result.gameObject.transform)
                {
                    _model.BuyItem(itemModel);
                    break;
                }
            }
        }


        public override void Clear()
        {
            base.Clear();

            _itemInfoPresenter.Clear();

            _model.OnChanged -= OnChanged;
            _model.OnGoldChanged -= OnGoldChanged;

            ClearItemOnInventories();
            ClearItemOnShops();
        }
    }
}