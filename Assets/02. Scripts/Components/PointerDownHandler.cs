using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GamePlay.Components
{
    public class PointerDownHandler : MonoBehaviour, IPointerDownHandler
    {
        public event Action OnPointerDowned;
        public void OnPointerDown(PointerEventData eventData)
        {
            OnPointerDowned?.Invoke();
        }

        public void Clear()
        {
            OnPointerDowned = null;
        }
    }
}


