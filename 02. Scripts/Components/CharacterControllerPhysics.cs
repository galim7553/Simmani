using UnityEngine;

namespace GamePlay.Components
{
    /// <summary>
    /// CharacterController�� ������� �������� �̵� �� ��ȣ�ۿ��� ó���ϴ� Ŭ����.
    /// </summary>
    [RequireComponent(typeof(CharacterController))]
    public class CharacterControllerPhysics : MonoBehaviour
    {
        [ReadOnly][SerializeField] CharacterController _characterController; // ĳ���� ��Ʈ�ѷ� ����
        [ReadOnly][SerializeField] Vector3 _velocity = Vector3.zero; // ���� �̵� �ӵ�
        [ReadOnly][SerializeField] bool _isGrounded = false; // ĳ���Ͱ� ���鿡 ���� ������ ����
        [SerializeField] float _gravityScale = 1.0f; // �߷� �����ϸ� ��
        [SerializeField] float _defaultVerticalSpeed = -2.0f; // �⺻ ���� �ӵ�
        [SerializeField] bool _useSlopeSlding = false; // ���� �����̵� ��� ����

        // ���� �����̵� ���� ����
        [ShowIf("_useSlopeSlding")][ReadOnly][SerializeField] Vector3 _slideDirection = Vector3.zero; // �����̵� ����
        [ShowIf("_useSlopeSlding")][SerializeField] float _slideSpeed = 5.0f; // �����̵� �ӵ�
        [ShowIf("_useSlopeSlding")][SerializeField] float _slideRayOriginOffset = 0.5f; // ���� �߻� ��ġ ������
        [ShowIf("_useSlopeSlding")][SerializeField] float _slideRayLength = 2.0f; // ���� ����
        [ShowIf("_useSlopeSlding")][SerializeField] LayerMask _slideRayLayerMask; // �����̵� ���� �浹 ���̾�

        public CharacterController CharacterController => _characterController;
        public Vector3 Velocity => _velocity;
        public bool IsGrounded => _isGrounded;
        public float GravityY => Physics.gravity.y * _gravityScale;

        RaycastHit _hit;

        /// <summary>
        /// Unity Inspector���� ���� ����� �� ȣ��Ǵ� �޼���.
        /// CharacterController�� �ڵ����� �ʱ�ȭ�մϴ�.
        /// </summary>
        private void OnValidate()
        {
            if (_characterController == null)
                _characterController = GetComponent<CharacterController>();
        }

        /// <summary>
        /// FixedUpdate �ֱ⿡�� ������ �̵��� ���¸� ������Ʈ�մϴ�.
        /// TBD: �����̵� �� ��ӵ� ����� ����. ���� �ӵ� �̻����� �����̵� �� �ǰ� ó��.
        /// </summary>
        private void FixedUpdate()
        {
            // ���鿡 ������ ���
            if (_characterController.isGrounded == true)
            {
                _isGrounded = true;

                // ���� �����̵� ó��
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
                    _velocity.y = _defaultVerticalSpeed; // �⺻ ���� �ӵ� ����
            }

            // ���߿� �ִ� ���
            else
            {
                _isGrounded = false;
                _velocity += Physics.gravity * _gravityScale * Time.fixedDeltaTime; // �߷� ����
            }

            _characterController.Move(_velocity * Time.fixedDeltaTime);
        }

        /// <summary>
        /// �ӵ��� X ���� �����մϴ�.
        /// </summary>
        public void SetVelocityX(float x)
        {
            _velocity.x = x;
        }

        /// <summary>
        /// �ӵ��� Y ���� �����մϴ�.
        /// </summary>
        public void SetVelocityY(float y)
        {
            _velocity.y = y;
        }

        /// <summary>
        /// �ӵ��� Z ���� �����մϴ�.
        /// </summary>
        public void SetVelocityZ(float z)
        {
            _velocity.z = z;
        }

        /// <summary>
        /// ĳ������ ��ġ�� �����մϴ�.
        /// </summary>
        /// <param name="position">���ο� ��ġ</param>
        public void SetPosition(Vector3 position)
        {
            _characterController.enabled = false;
            transform.position = position;
            _characterController.enabled = true;
        }
    }
}