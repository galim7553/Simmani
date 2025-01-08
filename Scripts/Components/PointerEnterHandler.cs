using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GamePlay.Components
{
    /// <summary>
    /// Pointer Enter 및 Exit 이벤트를 처리하는 핸들러.
    /// </summary>
    public class PointerEnterHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public event Action OnPointerEntered;
        public event Action OnPointerExited;

        public void OnPointerEnter(PointerEventData eventData)
        {
            OnPointerEntered?.Invoke();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            OnPointerExited?.Invoke();
        }
        public void Clear()
        {
            OnPointerEntered = null;
            OnPointerExited = null;
        }
    }
}