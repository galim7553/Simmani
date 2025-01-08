using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GamePlay.Components
{
    /// <summary>
    /// Pointer 다운 이벤트를 처리하는 핸들러.
    /// </summary>
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


