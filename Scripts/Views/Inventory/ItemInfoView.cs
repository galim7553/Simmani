using System;
using TMPro;
using UnityEngine.UI;

namespace GamePlay.Views
{
    /// <summary>
    /// �κ��丮���� ������ ������ ǥ���ϴ� UI ��.
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
        /// �並 �ʱ�ȭ�մϴ�.
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
        /// ��ư Ȱ��ȭ ���¸� �����մϴ�.
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


