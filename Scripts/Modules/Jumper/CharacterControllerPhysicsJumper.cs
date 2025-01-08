using System;
using GamePlay.Components;
using UnityEngine;

namespace GamePlay.Modules
{
    /// <summary>
    /// CharacterControllerPhysics 기반의 점프 구현 클래스.
    /// </summary>
    public class CharacterControllerPhysicsJumper : ModuleBase, IJumper, IFixedUpdatable
    {
        IJumperModel _model;
        CharacterControllerPhysics _physics;

        /// <summary>
        /// 점프 상태가 변경될 때 발생하는 이벤트.
        /// </summary>
        public event Action<IJumper.JumpState> OnJumpStateChanged;

        /// <summary>
        /// 현재 점프 상태.
        /// </summary>
        public IJumper.JumpState State { get; private set; } = IJumper.JumpState.OnGround;

        /// <summary>
        /// CharacterControllerPhysicsJumper 생성자.
        /// </summary>
        /// <param name="model">점프 모델</param>
        /// <param name="physics">물리 처리를 담당하는 CharacterControllerPhysics</param>
        public CharacterControllerPhysicsJumper(IJumperModel model, CharacterControllerPhysics physics)
        {
            _model = model;
            _physics = physics;
        }

        /// <summary>
        /// 점프 동작을 수행합니다.
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
        /// 점프 상태를 설정하고 이벤트를 호출합니다.
        /// </summary>
        void SetState(IJumper.JumpState state)
        {
            if (State == state) return;

            State = state;
            OnJumpStateChanged?.Invoke(State);
        }

        /// <summary>
        /// FixedUpdate 주기에서 점프 상태를 업데이트합니다.
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
        /// 모듈을 초기화합니다.
        /// </summary>
        public override void Clear()
        {
            OnJumpStateChanged = null;
        }
    }
}