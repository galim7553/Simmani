using System;
using UnityEngine;

namespace GamePlay.Components
{
    /// <summary>
    /// 충돌 이벤트를 처리하는 컴포넌트.
    /// </summary>
    public class CollisionHandler : MonoBehaviour
    {
        public event Action<Collision> OnCollisionEntered;
        public event Action<Collision> OnCollisionExited;
        public event Action<Collision> OnCollisionStaying;

        private void OnCollisionEnter(Collision collision)
        {
            OnCollisionEntered?.Invoke(collision);
        }

        private void OnCollisionExit(Collision collision)
        {
            OnCollisionExited?.Invoke(collision);
        }

        private void OnCollisionStay(Collision collision)
        {
            OnCollisionStaying?.Invoke(collision);
        }
    }
}


