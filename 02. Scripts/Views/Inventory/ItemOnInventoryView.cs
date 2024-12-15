using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GamePlay.Views
{
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

        public void SetAlphaOutlineActive(bool isActive)
        {

        }
    }
}


