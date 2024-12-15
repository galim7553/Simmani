using System;


namespace GamePlay.Modules
{
    public interface IJumper : IModule
    {
        enum JumpState
        {
            OnGround,
            Jumping,
            Falling,
        }
        enum JumpType
        {
            Velocity,
            Height
        }

        event Action<JumpState> OnJumpStateChanged;
        JumpState State { get; }

        void Jump();
    }
}