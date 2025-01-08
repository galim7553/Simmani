using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GamePlay.Components
{
    /// <summary>
    /// Pointer Ŭ�� �̺�Ʈ�� ó���ϴ� �ڵ鷯.
    /// </summary>
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

