using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GamePlay.Views
{
    public class HeroStatView : ViewBase
    {
        public enum ImageKey
        {
            HpBar,
            StaminaBar,
            FatigueBar,
        }

        private void Awake()
        {
            Bind<Image>(typeof(ImageKey));
        }

        public void SetImageFillAmount(int index, float amount)
        {
            GetImage(index).fillAmount = amount;
        }
    }
}


