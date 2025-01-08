using TMPro;
using UnityEngine;

namespace GamePlay.Views
{
    /// <summary>
    /// 인벤토리 메뉴를 표시하고 UI 요소를 관리하는 뷰.
    /// </summary>
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

        /// <summary>
        /// 뷰를 초기화.
        /// </summary>
        public void Initialize()
        {
            if (_hasInitialized == true) return;

            Bind<Transform>(typeof(TransformKey));
            Bind<TextMeshProUGUI>(typeof(TMPKey));
            Bind<ItemInfoView>(typeof(ItemInfoViewKey));

            _hasInitialized = true;
        }

        /// <summary>
        /// 인벤토리에 아이템 뷰를 추가.
        /// </summary>
        public void AddItemOnInventoryView(ItemOnInventoryView view)
        {
            view.transform.SetParent(GetTransform((int)TransformKey.ItemOnInventoryParent), false);
            view.transform.SetAsLastSibling();
        }


        /// <summary>
        /// 상점에 아이템 뷰를 추가.
        /// </summary>
        public void AddItemOnShopView(ItemOnInventoryView view)
        {
            view.transform.SetParent(GetTransform((int)TransformKey.ItemOnShopParent), false);
            view.transform.SetAsLastSibling();
        }

        /// <summary>
        /// UI 컴포넌트의 활성화 상태를 설정.
        /// </summary>
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


