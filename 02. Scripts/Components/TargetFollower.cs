using UnityEngine;

namespace GamePlay.Components
{
    /// <summary>
    /// ������ Ÿ���� ���󰡴� ������Ʈ.
    /// </summary>
    public class TargetFollower : MonoBehaviour
    {
        [SerializeField] Transform _target;
        [SerializeField] Vector3 _offset;

        /// <summary>
        /// ���� Ÿ���� �����մϴ�.
        /// </summary>
        /// <param name="target">Ÿ�� Transform</param>
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


