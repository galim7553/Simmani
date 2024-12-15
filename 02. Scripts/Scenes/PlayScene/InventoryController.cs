using System.Collections;
using System.Collections.Generic;
using GamePlay.Datas;
using GamePlay.Factories;
using GamePlay.Hubs;
using GamePlay.Presenters;
using GamePlay.Views;
using GamePlay.Modules;
using UnityEngine;

namespace GamePlay.Scene
{
    public class InventoryController : IInventoryController
    {
        IInventoryModel _inventoryModel;
        InventoryMenuView _inventoryMenuView;

        InventoryMenuPresenter _inventoryMenuPresenter;

        public bool IsActive => _inventoryMenuPresenter.IsVisible;

        public InventoryController(IInventoryModel inventoryModel, HeroModel heroModel,
            InventoryMenuView inventoryMenuView,  ViewFactory viewFactory)
        {
            _inventoryModel = inventoryModel;
            _inventoryMenuView = inventoryMenuView;

            _inventoryMenuPresenter = new InventoryMenuPresenter(_inventoryModel, _inventoryMenuView, viewFactory);
        }

        public void ToggleInventory()
        {
            DisplayInventory(!IsActive);
        }
        public void DisplayInventory(bool isVisible, IShopModel shopModel = null)
        {
            _inventoryMenuPresenter.DisplayInventoryMenu(isVisible, shopModel);
            if (_inventoryMenuPresenter.IsVisible)
            {
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }

        public void Clear()
        {
            _inventoryMenuPresenter.Clear();
        }
    }
}