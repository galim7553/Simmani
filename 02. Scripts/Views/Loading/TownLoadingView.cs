using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GamePlay.Views
{
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


