using UnityEngine;

namespace GamePlay.Components
{
    /// <summary>
    /// CharacterController를 기반으로 물리적인 이동 및 상호작용을 처리하는 클래스.
    /// </summary>
    [RequireComponent(typeof(CharacterController))]
    public class CharacterControllerPhysics : MonoBehaviour
    {
        [ReadOnly][SerializeField] CharacterController _characterController; // 캐릭터 컨트롤러 참조
        [ReadOnly][SerializeField] Vector3 _velocity = Vector3.zero; // 현재 이동 속도
        [ReadOnly][SerializeField] bool _isGrounded = false; // 캐릭터가 지면에 접촉 중인지 여부
        [SerializeField] float _gravityScale = 1.0f; // 중력 스케일링 값
        [SerializeField] float _defaultVerticalSpeed = -2.0f; // 기본 수직 속도
        [SerializeField] bool _useSlopeSlding = false; // 경사면 슬라이딩 사용 여부

        // 경사면 슬라이딩 관련 변수
        [ShowIf("_useSlopeSlding")][ReadOnly][SerializeField] Vector3 _slideDirection = Vector3.zero; // 슬라이딩 방향
        [ShowIf("_useSlopeSlding")][SerializeField] float _slideSpeed = 5.0f; // 슬라이딩 속도
        [ShowIf("_useSlopeSlding")][SerializeField] float _slideRayOriginOffset = 0.5f; // 레이 발사 위치 오프셋
        [ShowIf("_useSlopeSlding")][SerializeField] float _slideRayLength = 2.0f; // 레이 길이
        [ShowIf("_useSlopeSlding")][SerializeField] LayerMask _slideRayLayerMask; // 슬라이딩 레이 충돌 레이어

        public CharacterController CharacterController => _characterController;
        public Vector3 Velocity => _velocity;
        public bool IsGrounded => _isGrounded;
        public float GravityY => Physics.gravity.y * _gravityScale;

        RaycastHit _hit;

        /// <summary>
        /// Unity Inspector에서 값이 변경될 때 호출되는 메서드.
        /// CharacterController를 자동으로 초기화합니다.
        /// </summary>
        private void OnValidate()
        {
            if (_characterController == null)
                _characterController = GetComponent<CharacterController>();
        }

        /// <summary>
        /// FixedUpdate 주기에서 물리적 이동과 상태를 업데이트합니다.
        /// TBD: 슬라이딩 시 등가속도 운동으로 변경. 일정 속도 이상으로 슬라이딩 시 피격 처리.
        /// </summary>
        private void FixedUpdate()
        {
            // 지면에 접촉한 경우
            if (_characterController.isGrounded == true)
            {
                _isGrounded = true;

                // 경사면 슬라이딩 처리
                if (_useSlopeSlding == true)
                {
                    if (Physics.Raycast(transform.position + Vector3.up * _slideRayOriginOffset,
                        Vector3.down, out _hit, _slideRayLength, _slideRayLayerMask))
                    {
                        float slopeAngle = Vector3.Angle(_hit.normal, Vector3.up);
                        if (slopeAngle > _characterController.slopeLimit)
                        {
                            _isGrounded = false;

                            _slideDirection.x = _hit.normal.x;
                            _slideDirection.y = -_hit.normal.y;
                            _slideDirection.z = _hit.normal.z;
                            _characterController.Move(_slideDirection * _slideSpeed * Time.fixedDeltaTime);
                        }
                    }
                }

                if (_velocity.y < 0)
                    _velocity.y = _defaultVerticalSpeed; // 기본 수직 속도 적용
            }

            // 공중에 있는 경우
            else
            {
                _isGrounded = false;
                _velocity += Physics.gravity * _gravityScale * Time.fixedDeltaTime; // 중력 적용
            }

            _characterController.Move(_velocity * Time.fixedDeltaTime);
        }

        /// <summary>
        /// 속도의 X 값을 설정합니다.
        /// </summary>
        public void SetVelocityX(float x)
        {
            _velocity.x = x;
        }

        /// <summary>
        /// 속도의 Y 값을 설정합니다.
        /// </summary>
        public void SetVelocityY(float y)
        {
            _velocity.y = y;
        }

        /// <summary>
        /// 속도의 Z 값을 설정합니다.
        /// </summary>
        public void SetVelocityZ(float z)
        {
            _velocity.z = z;
        }

        /// <summary>
        /// 캐릭터의 위치를 설정합니다.
        /// </summary>
        /// <param name="position">새로운 위치</param>
        public void SetPosition(Vector3 position)
        {
            _characterController.enabled = false;
            transform.position = position;
            _characterController.enabled = true;
        }
    }
}