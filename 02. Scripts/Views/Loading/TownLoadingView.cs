using TMPro;
using UnityEngine.UI;

namespace GamePlay.Views
{
    /// <summary>
    /// 마을 로딩 화면의 UI 요소를 관리하는 뷰.
    /// </summary>
    public class TownLoadingView : ViewBase
    {
        public enum TMPKey
        {
            DayText,
            RequiredSansamCountText,
            KoreanHourText
        }
        public enum ImageKey
        {
            KoreanHourImage
        }
        private void Awake()
        {
            Bind<TextMeshProUGUI>(typeof(TMPKey));
            Bind<Image>(typeof(ImageKey));
        }
    }
}


