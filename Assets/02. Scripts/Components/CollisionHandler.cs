using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Components
{
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


