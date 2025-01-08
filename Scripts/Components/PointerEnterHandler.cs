using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GamePlay.Components
{
    /// <summary>
    /// Pointer Enter �� Exit �̺�Ʈ�� ó���ϴ� �ڵ鷯.
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