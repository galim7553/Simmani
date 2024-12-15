using System;
using System.Collections;
using System.Collections.Generic;
using GamePlay.Components;
using UnityEngine;

namespace GamePlay.Modules
{
    public class CharacterControllerPhysicsJumper : ModuleBase, IJumper, IFixedUpdatable
    {
        IJumperModel _model;
        CharacterControllerPhysics _physics;

        public event Action<IJumper.JumpState> OnJumpStateChanged;

        public IJumper.JumpState State { get; private set; } = IJumper.JumpState.OnGround;

        public CharacterControllerPhysicsJumper(IJumperModel model, CharacterControllerPhysics physics)
        {
            _model = model;
            _physics = physics;
        }

        public void Jump()
        {
            if (!IsActive) return;

            if(State == IJumper.JumpState.OnGround)
            {
                if(_model.JumpType == IJumper.JumpType.Velocity)
                    _physics.SetVelocityY(_model.JumpSpeed);
                else if(_model.JumpType == IJumper.JumpType.Height)
                {
                    float gravity = _physics.GravityY;
                    _physics.SetVelocityY(Mathf.Sqrt(-2 * gravity * _model.JumpHeight));
                }
            }
                
        }
        void SetState(IJumper.JumpState state)
        {
            if (State == state) return;

            State = state;
            OnJumpStateChanged?.Invoke(State);
        }

        public void OnFixedUpdate()
        {
            if (_physics.IsGrounded == true)
                SetState(IJumper.JumpState.OnGround);
            else
            {
                if (_physics.Velocity.y > 0)
                    SetState(IJumper.JumpState.Jumping);
                else
                    SetState(IJumper.JumpState.Falling);
            }
        }

        public override void Clear()
        {
            OnJumpStateChanged = null;
        }
    }
}


