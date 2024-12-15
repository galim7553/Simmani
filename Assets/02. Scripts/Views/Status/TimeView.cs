using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GamePlay.Views
{
    public class TimeView : ViewBase
    {
        public enum ImageKey
        {
            TimeImage
        }

        private void Awake()
        {
            Bind<Image>(typeof(ImageKey));
        }
    }

}