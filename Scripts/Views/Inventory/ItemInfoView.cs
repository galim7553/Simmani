using System;
using TMPro;
using UnityEngine.UI;

namespace GamePlay.Views
{
    /// <summary>
    /// 인벤토리에서 아이템 정보를 표시하는 UI 뷰.
    /// </summary>
    public class ItemInfoView : ViewBase
    {
        public enum ImageKey
        {
            ItemImage
        }
        public enum TMPKey
        {
            ItemNameText,
            ItemDescriptionText,
            PriceText,
            UseButtonText,
            DumpButtonText
        }
        public enum ButtonKey
        {
            UseButton,
            DumpButton
        }

        bool _hasInitialized = false;

        public event Action OnUseButtonClicked;
        public event Action OnDumpButtonClicked;

        /// <summary>
        /// 뷰를 초기화합니다.
        /// </summary>
        public void Initialize()
        {
            if (_hasInitialized == true) return;

            Bind<Image>(typeof(ImageKey));
            Bind<TextMeshProUGUI>(typeof(TMPKey));
            Bind<Button>(typeof(ButtonKey));

            GetButton((int)ButtonKey.UseButton).onClick.AddListener(() => OnUseButtonClicked?.Invoke());
            GetButton((int)ButtonKey.DumpButton).onClick.AddListener(() => OnDumpButtonClicked?.Invoke());

            _hasInitialized = true;
        }

        /// <summary>
        /// 버튼 활성화 상태를 설정합니다.
        /// </summary>
        public void SetButtonActive(ButtonKey buttonKey, bool isActive)
        {
            GetButton((int)buttonKey).gameObject.SetActive(isActive);
        }

        public override void Clear()
        {
            base.Clear();

            OnUseButtonClicked = null;
            OnDumpButtonClicked = null;
        }
    }
}


