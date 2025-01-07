using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GamePlay.Components
{
    /// <summary>
    /// Pointer 클릭 이벤트를 처리하는 핸들러.
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

