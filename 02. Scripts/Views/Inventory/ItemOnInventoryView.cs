using UnityEngine.UI;

namespace GamePlay.Views
{
    /// <summary>
    /// 인벤토리에서 아이템의 UI를 처리하는 뷰.
    /// </summary>
    public class ItemOnInventoryView : ViewBase
    {
        public enum ImageKey
        {
            ItemImage
        }

        Image _image;

        private void Awake()
        {
            _image = GetComponent<Image>();
            Bind<Image>(typeof(ImageKey));
        }

        /// <summary>
        /// 알파 외곽선 효과 활성화 상태를 설정합니다.
        /// </summary>
        public void SetAlphaOutlineActive(bool isActive)
        {
            // TBD: 외곽선 활성화 로직 구현 필요
        }
    }
}


