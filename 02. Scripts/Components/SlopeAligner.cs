using UnityEngine;

namespace GamePlay.Components
{
    public class SlopeAligner : MonoBehaviour
    {
        [SerializeField] Transform _frontPoint; // ������Ʈ�� ���� ����ĳ��Ʈ ����Ʈ
        [SerializeField] Transform _backPoint;  // ������Ʈ�� ���� ����ĳ��Ʈ ����Ʈ
        [SerializeField] float _rayLength = 5f; // ����ĳ��Ʈ ����
        [SerializeField] LayerMask _groundLayer; // ���� �ش��ϴ� ���̾�
        [SerializeField] float _positionThreshold = 0.1f;

        Vector3 _prevPosition;

        Vector3? _frontHitPoint; // ���� ����ĳ��Ʈ ��Ʈ ����
        Vector3? _backHitPoint;  // ���� ����ĳ��Ʈ ��Ʈ ����

        void Start()
        {
            _prevPosition = transform.position;
        }

        void Update()
        {
            if(Vector3.Distance(transform.position, _prevPosition) >= _positionThreshold)
            {
                AlignToSlope();
                _prevPosition = transform.position;
            }
        }

        void AlignToSlope()
        {
            // ���� ����ĳ��Ʈ
            if (Physics.Raycast(_frontPoint.position, Vector3.down, out RaycastHit frontHit, _rayLength, _groundLayer))
            {
                _frontHitPoint = frontHit.point;
                // ���� ����ĳ��Ʈ
                if (Physics.Raycast(_backPoint.position, Vector3.down, out RaycastHit backHit, _rayLength, _groundLayer))
                {
                    _backHitPoint = backHit.point;
                    // ���� �� ���
                    float heightDifference = frontHit.point.y - backHit.point.y;

                    // �յ� ���� �Ÿ� (z�� �Ÿ�)
                    float distance = Vector3.Distance(_frontPoint.position, _backPoint.position);

                    // ȸ�� ���� ���
                    float angle = Mathf.Atan2(heightDifference, distance) * Mathf.Rad2Deg;

                    // x�� ȸ�� ����
                    transform.localRotation = Quaternion.Euler(-angle, transform.localRotation.eulerAngles.y, transform.localRotation.eulerAngles.z);
                }
                else
                    _backHitPoint = null;
            }
            else
                _frontHitPoint = null;
        }

        private void OnDrawGizmos()
        {
            // ����ĳ��Ʈ�� �ð������� �����
            if (_frontPoint != null)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawLine(_frontPoint.position, _frontPoint.position + Vector3.down * _rayLength);

                // ���� ��Ʈ ���� ǥ��
                if (_frontHitPoint.HasValue)
                {
                    Gizmos.DrawSphere(_frontHitPoint.Value, 0.2f); // ��Ʈ ������ ��ü ǥ��
                }
            }
            if (_backPoint != null)
            {
                Gizmos.color = Color.blue;
                Gizmos.DrawLine(_backPoint.position, _backPoint.position + Vector3.down * _rayLength);

                // ���� ��Ʈ ���� ǥ��
                if (_backHitPoint.HasValue)
                {
                    Gizmos.DrawSphere(_backHitPoint.Value, 0.2f); // ��Ʈ ������ ��ü ǥ��
                }
            }
        }
    }
}
