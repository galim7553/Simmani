using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GamePlay.Views
{
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