using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GamePlay.Components
{
    /// <summary>
    /// Pointer �ٿ� �̺�Ʈ�� ó���ϴ� �ڵ鷯.
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


