using TMPro;
using UnityEngine.UI;

namespace GamePlay.Views
{
    /// <summary>
    /// 개별 핫키 UI를 제어하는 뷰 클래스.
    /// </summary>
    public class HotKeyView : ViewBase
    {
        public enum ImageKey
        {
            ItemImage,
        }
        public enum TMPKey
        {
            CountText,
        }

        private void Awake()
        {
            Bind<Image>(typeof(ImageKey));
            Bind<TextMeshProUGUI>(typeof(TMPKey));
        }
    }

}