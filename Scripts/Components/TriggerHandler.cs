using System;
using UnityEngine;

namespace GamePlay.Components
{
    /// <summary>
    /// Ʈ���� �̺�Ʈ�� ó���ϴ� ������Ʈ.
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

