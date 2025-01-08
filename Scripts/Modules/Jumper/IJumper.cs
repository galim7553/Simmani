using System;

namespace GamePlay.Modules
{
    /// <summary>
    /// ���� ������ �����ϴ� �������̽�.
    /// </summary>
    public interface IJumper : IModule
    {
        /// <summary>
        /// ���� ���¸� ��Ÿ���� ������.
        /// </summary>
        enum JumpState
        {
            OnGround,   // ���鿡 ����
            Jumping,    // ���� ��
            Falling     // ���߿��� ������
        }

        /// <summary>
        /// ���� Ÿ���� ��Ÿ���� ������.
        /// </summary>
        enum JumpType
        {
            Velocity,   // �ӵ��� �̿��� ����
            Height      // ���̸� �������� ����� ����
        }

        /// <summary>
        /// ���� ���°� ����� �� �߻��ϴ� �̺�Ʈ.
        /// </summary>
        event Action<JumpState> OnJumpStateChanged;

        /// <summary>
        /// ���� ���� ����.
        /// </summary>
        JumpState State { get; }

        /// <summary>
        /// ���� ������ �����մϴ�.
        /// </summary>
        void Jump();
    }
}
