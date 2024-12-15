using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GamePlay.Components
{
    public class PointerClickHandler : MonoBehaviour, IPointerClickHandler
    {
        public event Action OnPointerClicked;
        public void OnPointerClick(PointerEventData eventData)
        {
            OnPointerClicked?.Invoke();
        }

        public void Clear()
        {
            OnPointerClicked = null;
        }
    }

}

