using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Components
{
    public class TargetFollower : MonoBehaviour
    {
        [SerializeField] Transform _target;
        [SerializeField] Vector3 _offset;
        public void SetTarget(Transform target)
        {
            _target = target;
            transform.position = _target.position + _offset;
        }

        private void Update()
        {
            if (_target != null)
            {
                transform.position = _target.position + _offset;
            }
        }
    }
}


