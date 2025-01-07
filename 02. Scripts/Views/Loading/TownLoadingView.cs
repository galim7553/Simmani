using TMPro;
using UnityEngine.UI;

namespace GamePlay.Views
{
    /// <summary>
    /// ���� �ε� ȭ���� UI ��Ҹ� �����ϴ� ��.
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


