using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Modules
{
    /*
    public class RigidbodyJumper : ModuleBase, IJumper, IFixedUpdatable
    {
        Rigidbody _rigidbody;

        float _jumpSpeed;
        float _maxFallSpeed;
        int _maxJumpCount;
        float _gravity;
        LayerMask _groundLayer;

        float _rayOffset;
        float _rayDistance;

        IJumper.JumpState _state = IJumper.JumpState.Jumping;
        int _jumpCount;
        Vector3 _velocity = Vector3.zero;

        Ray _ray = new Ray();
        RaycastHit _hit;

        public event Action<IJumper.JumpState> onJumpStateChanged;

        public RigidbodyJumper(Rigidbody rigidbody,
            float jumpSpeed, float maxFallSpeed, float gravity, int maxJumpCount,
            LayerMask groundLayer,
            float rayOffset, float rayDistance)
        {
            _rigidbody = rigidbody;

            SetJumpSpeed(jumpSpeed);
            SetMaxFallSpeed(maxFallSpeed);
            SetGravity(gravity);
            SetMaxJumpCount(maxJumpCount);
            SetGroundLayer(groundLayer);

            _rayOffset = rayOffset;
            _rayDistance = rayDistance;
        }

        void SetState(IJumper.JumpState state)
        {
            if (_state == state) return;

            _state = state;
            if (_state == IJumper.JumpState.OnGround)
            {
                RecoverJumpCount();
            }

            onJumpStateChanged?.Invoke(_state);
        }

        public void OnFixedUpdate()
        {
            _velocity = _rigidbody.velocity;

            // y�� �ӷ��� �ſ� ���� ���� RayCast�� ���� ����
            // �浹�� ���� ������ �� ��� �ͷ��ο� ȣȯ���� ����
            if (Mathf.Abs(_velocity.y) < Util.EPSILON)
            {
                // y�� �ӷ��� �ſ� �����鼭, ����� �ſ� ������ ���� ���·� ����
                if (ComputeIsGround())
                {
                    SetState(IJumper.JumpState.OnGround);
                    return;
                }
            }

            // ������ �������� �ʾ��� ���
            // y�� �ӷ� �߷¿� ���� ��ȭ
            SetVelocityY(Mathf.Max(_velocity.y - _gravity * Time.fixedDeltaTime, -_maxFallSpeed));
            _rigidbody.velocity = _velocity;

            if (_velocity.y > 0)
                SetState(IJumper.JumpState.Jumping);
            else
                SetState(IJumper.JumpState.Falling);
        }

        public void Jump()
        {
            if (IsActive == false) return;

            if (_jumpCount > 0)
            {
                SetVelocityY(_jumpSpeed);
                _jumpCount--;
            }
        }

        void RecoverJumpCount()
        {
            _jumpCount = _maxJumpCount;
        }

        void SetVelocityY(float velocityY)
        {
            _velocity = _rigidbody.velocity;
            _velocity.y = velocityY;
            _rigidbody.velocity = _velocity;
        }
        bool ComputeIsGround()
        {
            _ray.origin = _rigidbody.position + Vector3.up * _rayOffset;
            _ray.direction = Vector3.down;
            return Physics.Raycast(_ray, out _hit, _rayOffset + _rayDistance, _groundLayer);
        }




        public void SetJumpSpeed(float speed)
        {
            _jumpSpeed = speed;
        }

        public void SetMaxJumpCount(int maxJumpCount)
        {
            _maxJumpCount = maxJumpCount;
        }

        public void SetMaxFallSpeed(float maxFallSpeed)
        {
            _maxFallSpeed = maxFallSpeed;
        }

        public void SetGravity(float gravity)
        {
            _gravity = gravity;
        }
        public void SetGroundLayer(LayerMask groundLayer)
        {
            _groundLayer = groundLayer;
        }
    }



    */
}


