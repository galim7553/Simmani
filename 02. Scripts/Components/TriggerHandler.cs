using System;
using UnityEngine;

namespace GamePlay.Components
{
    /// <summary>
    /// 트리거 이벤트를 처리하는 컴포넌트.
    /// </summary>
    public class TriggerHandler : MonoBehaviour
    {
        public event Action<Collider> OnTriggerEntered;
        public event Action<Collider> OnTriggerExited;
        public event Action<Collider> OnTriggerStaying;

        private void OnTriggerEnter(Collider other)
        {
            OnTriggerEntered?.Invoke(other);
        }
        private void OnTriggerExit(Collider other)
        {
            OnTriggerExited?.Invoke(other);
        }
        private void OnTriggerStay(Collider other)
        {
            OnTriggerStaying?.Invoke(other);
        }

        public void Clear()
        {
            OnTriggerEntered = null;
            OnTriggerExited = null;
            OnTriggerStaying = null;
        }
    }
}

