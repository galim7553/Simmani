using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GamePlay.Views
{
    public class InventoryMenuView : ViewBase
    {
        public enum TransformKey
        {
            ItemOnInventoryParent,
            ItemOnShopParent,
            InventoryPanel,
            ShopPanel,
            SellGuidePanel,
            BuyGuidePanel,
        }
        public enum TMPKey
        {
            ShopTitleText,
            GoldText,
            BagInfoText,
            SellGuideText,
            BuyGuideText,
        }
        public enum ItemInfoViewKey
        {
            ItemInfoView,
        }

        bool _hasInitialized = false;

        public void Initialize()
        {
            if (_hasInitialized == true) return;

            Bind<Transform>(typeof(TransformKey));
            Bind<TextMeshProUGUI>(typeof(TMPKey));
            Bind<ItemInfoView>(typeof(ItemInfoViewKey));

            _hasInitialized = true;
        }

        public void AddItemOnInventoryView(ItemOnInventoryView view)
        {
            view.transform.SetParent(GetTransform((int)TransformKey.ItemOnInventoryParent), false);
            view.transform.SetAsLastSibling();
        }
        public void AddItemOnShopView(ItemOnInventoryView view)
        {
            view.transform.SetParent(GetTransform((int)TransformKey.ItemOnShopParent), false);
            view.transform.SetAsLastSibling();
        }

        public void SetComponentActive(TransformKey transformKey, bool isActive)
        {
            GetTransform((int)transformKey).gameObject.SetActive(isActive);
        }
        public Transform GetTransform(TransformKey transformKey)
        {
            return GetTransform((int)transformKey);
        }
        public ItemInfoView GetItemInfoView(ItemInfoViewKey itemInfoViewKey)
        {
            return Get<ItemInfoView>((int)itemInfoViewKey);
        }
    }
}


