using UnityEngine;

namespace GamePlay.Components
{
    /// <summary>
    /// 지정된 타겟을 따라가는 컴포넌트.
    /// </summary>
    public class TargetFollower : MonoBehaviour
    {
        [SerializeField] Transform _target;
        [SerializeField] Vector3 _offset;

        /// <summary>
        /// 따라갈 타겟을 설정합니다.
        /// </summary>
        /// <param name="target">타겟 Transform</param>
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


