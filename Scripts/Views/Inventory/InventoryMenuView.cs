using TMPro;
using UnityEngine;

namespace GamePlay.Views
{
    /// <summary>
    /// �κ��丮 �޴��� ǥ���ϰ� UI ��Ҹ� �����ϴ� ��.
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
        /// �並 �ʱ�ȭ.
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
        /// �κ��丮�� ������ �並 �߰�.
        /// </summary>
        public void AddItemOnInventoryView(ItemOnInventoryView view)
        {
            view.transform.SetParent(GetTransform((int)TransformKey.ItemOnInventoryParent), false);
            view.transform.SetAsLastSibling();
        }


        /// <summary>
        /// ������ ������ �並 �߰�.
        /// </summary>
        public void AddItemOnShopView(ItemOnInventoryView view)
        {
            view.transform.SetParent(GetTransform((int)TransformKey.ItemOnShopParent), false);
            view.transform.SetAsLastSibling();
        }

        /// <summary>
        /// UI ������Ʈ�� Ȱ��ȭ ���¸� ����.
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


