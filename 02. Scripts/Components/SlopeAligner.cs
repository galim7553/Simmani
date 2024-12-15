using UnityEngine;

namespace GamePlay.Components
{
    public class SlopeAligner : MonoBehaviour
    {
        [SerializeField] Transform _frontPoint; // 오브젝트의 앞쪽 레이캐스트 포인트
        [SerializeField] Transform _backPoint;  // 오브젝트의 뒤쪽 레이캐스트 포인트
        [SerializeField] float _rayLength = 5f; // 레이캐스트 길이
        [SerializeField] LayerMask _groundLayer; // 땅에 해당하는 레이어
        [SerializeField] float _positionThreshold = 0.1f;

        Vector3 _prevPosition;

        Vector3? _frontHitPoint; // 앞쪽 레이캐스트 히트 지점
        Vector3? _backHitPoint;  // 뒤쪽 레이캐스트 히트 지점

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
            // 앞쪽 레이캐스트
            if (Physics.Raycast(_frontPoint.position, Vector3.down, out RaycastHit frontHit, _rayLength, _groundLayer))
            {
                _frontHitPoint = frontHit.point;
                // 뒤쪽 레이캐스트
                if (Physics.Raycast(_backPoint.position, Vector3.down, out RaycastHit backHit, _rayLength, _groundLayer))
                {
                    _backHitPoint = backHit.point;
                    // 높이 차 계산
                    float heightDifference = frontHit.point.y - backHit.point.y;

                    // 앞뒤 간의 거리 (z축 거리)
                    float distance = Vector3.Distance(_frontPoint.position, _backPoint.position);

                    // 회전 각도 계산
                    float angle = Mathf.Atan2(heightDifference, distance) * Mathf.Rad2Deg;

                    // x축 회전 적용
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
            // 레이캐스트를 시각적으로 디버그
            if (_frontPoint != null)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawLine(_frontPoint.position, _frontPoint.position + Vector3.down * _rayLength);

                // 앞쪽 히트 지점 표시
                if (_frontHitPoint.HasValue)
                {
                    Gizmos.DrawSphere(_frontHitPoint.Value, 0.2f); // 히트 지점에 구체 표시
                }
            }
            if (_backPoint != null)
            {
                Gizmos.color = Color.blue;
                Gizmos.DrawLine(_backPoint.position, _backPoint.position + Vector3.down * _rayLength);

                // 뒤쪽 히트 지점 표시
                if (_backHitPoint.HasValue)
                {
                    Gizmos.DrawSphere(_backHitPoint.Value, 0.2f); // 히트 지점에 구체 표시
                }
            }
        }
    }
}
