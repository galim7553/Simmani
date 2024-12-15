using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace GamePlay.Views
{
    public class StageView : ViewBase
    {
        public enum TMPKey
        {
            SansamCountText
        }

        private void Awake()
        {
            Bind<TextMeshProUGUI>(typeof(TMPKey));
        }
    }

}