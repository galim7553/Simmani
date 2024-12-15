using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Components
{
    [RequireComponent(typeof(CharacterController))]
    public class CharacterControllerPhysics : MonoBehaviour
    {

        [ReadOnly][SerializeField] CharacterController _characterController;
        [ReadOnly][SerializeField] Vector3 _velocity = Vector3.zero;
        [ReadOnly][SerializeField] bool _isGrounded = false;
        [SerializeField] float _gravityScale = 1.0f;
        [SerializeField] float _defaultVerticalSpeed = -2.0f;
        [SerializeField] bool _useSlopeSlding = false;
        
        [ShowIf("_useSlopeSlding")][ReadOnly][SerializeField] Vector3 _slideDirection = Vector3.zero;
        [ShowIf("_useSlopeSlding")][SerializeField] float _slideSpeed = 5.0f;
        [ShowIf("_useSlopeSlding")][SerializeField] float _slideRayOriginOffset = 0.5f;
        [ShowIf("_useSlopeSlding")][SerializeField] float _slideRayLength = 2.0f;
        [ShowIf("_useSlopeSlding")][SerializeField] LayerMask _slideRayLayerMask;

        public CharacterController CharacterController { get { return _characterController; } }
        public Vector3 Velocity => _velocity;
        public bool IsGrounded => _isGrounded;
        public float GravityY => Physics.gravity.y * _gravityScale;



        RaycastHit _hit;

        private void OnValidate()
        {
            if(_characterController == null)
                _characterController = GetComponent<CharacterController>();
        }

        private void FixedUpdate()
        {

            // 지상에 있는 경우
            if (_characterController.isGrounded == true)
            {
                _isGrounded = true;
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
                    _velocity.y = _defaultVerticalSpeed;
            }

            // 공중에 있는 경우
            else
            {
                _isGrounded = false;
                _velocity += Physics.gravity * _gravityScale * Time.fixedDeltaTime;
            }

            _characterController.Move(_velocity * Time.fixedDeltaTime);
        }

        public void SetVelocityX(float x)
        {
            _velocity.x = x;
        }
        public void SetVelocityY(float y)
        {
            _velocity.y = y;
        }
        public void SetVelocityZ(float z)
        {
            _velocity.z = z;
        }

        public void SetPosition(Vector3 position)
        {
            _characterController.enabled = false;
            transform.position = position;
            _characterController.enabled = true;
        }
    }
}


