using System;
using GamePlay.Components;
using UnityEngine;

namespace GamePlay.Modules
{
    /// <summary>
    /// CharacterControllerPhysics ����� ���� ���� Ŭ����.
    /// </summary>
    public class CharacterControllerPhysicsJumper : ModuleBase, IJumper, IFixedUpdatable
    {
        IJumperModel _model;
        CharacterControllerPhysics _physics;

        /// <summary>
        /// ���� ���°� ����� �� �߻��ϴ� �̺�Ʈ.
        /// </summary>
        public event Action<IJumper.JumpState> OnJumpStateChanged;

        /// <summary>
        /// ���� ���� ����.
        /// </summary>
        public IJumper.JumpState State { get; private set; } = IJumper.JumpState.OnGround;

        /// <summary>
        /// CharacterControllerPhysicsJumper ������.
        /// </summary>
        /// <param name="model">���� ��</param>
        /// <param name="physics">���� ó���� ����ϴ� CharacterControllerPhysics</param>
        public CharacterControllerPhysicsJumper(IJumperModel model, CharacterControllerPhysics physics)
        {
            _model = model;
            _physics = physics;
        }

        /// <summary>
        /// ���� ������ �����մϴ�.
        /// </summary>
        public void Jump()
        {
            if (!IsActive) return;

            if (State == IJumper.JumpState.OnGround)
            {
                if (_model.JumpType == IJumper.JumpType.Velocity)
                    _physics.SetVelocityY(_model.JumpSpeed);
                else if (_model.JumpType == IJumper.JumpType.Height)
                {
                    float gravity = _physics.GravityY;
                    _physics.SetVelocityY(Mathf.Sqrt(-2 * gravity * _model.JumpHeight));
                }
            }
        }

        /// <summary>
        /// ���� ���¸� �����ϰ� �̺�Ʈ�� ȣ���մϴ�.
        /// </summary>
        void SetState(IJumper.JumpState state)
        {
            if (State == state) return;

            State = state;
            OnJumpStateChanged?.Invoke(State);
        }

        /// <summary>
        /// FixedUpdate �ֱ⿡�� ���� ���¸� ������Ʈ�մϴ�.
        /// </summary>
        public void OnFixedUpdate()
        {
            if (_physics.IsGrounded)
                SetState(IJumper.JumpState.OnGround);
            else
            {
                if (_physics.Velocity.y > 0)
                    SetState(IJumper.JumpState.Jumping);
                else
                    SetState(IJumper.JumpState.Falling);
            }
        }

        /// <summary>
        /// ����� �ʱ�ȭ�մϴ�.
        /// </summary>
        public override void Clear()
        {
            OnJumpStateChanged = null;
        }
    }
}