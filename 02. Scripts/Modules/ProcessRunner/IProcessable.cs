using System;

namespace GamePlay.Modules
{
    /// <summary>
    /// ó�� ������ �۾�(Processable)�� �������̽��� �����մϴ�.
    /// </summary>
    public interface IProcessable
    {
        /// <summary>
        /// �۾��� ������ ��Ÿ���ϴ�.
        /// </summary>
        public enum ProcessType
        {
            Idle,
            Loot,
        }

        /// <summary>
        /// �۾� ������ ��ȯ�մϴ�.
        /// </summary>
        ProcessType Type { get; }

        /// <summary>
        /// �۾� �Ϸῡ �ʿ��� �ð�(��)�� ��ȯ�մϴ�.
        /// </summary>
        float Amount { get; }

        /// <summary>
        /// �۾� ���� �� ȣ��Ǵ� �׼��Դϴ�.
        /// </summary>
        Action OnSuccess { get; }

        /// <summary>
        /// �۾� ���� �� ȣ��Ǵ� �׼��Դϴ�.
        /// </summary>
        Action OnFailed { get; }
    }

}

