using System;

namespace GamePlay.Modules
{
    /// <summary>
    /// ������Ʈ ����� ��Ÿ�� �����͸� �����ϴ� �������̽�.
    /// </summary>
    public interface ISprinterModel
    {
        /// <summary>
        /// ������Ʈ ����.
        /// </summary>
        ISprinterConfig Config { get; }

        /// <summary>
        /// ���� ������Ʈ ����.
        /// </summary>
        bool IsSprinting { get; }

        /// <summary>
        /// �ִ� ���¹̳� ��.
        /// </summary>
        float MaxStamina { get; }

        /// <summary>
        /// ���� ���¹̳� ��.
        /// </summary>
        float Stamina { get; }

        /// <summary>
        /// ���¹̳� ���� ����� �� ȣ��Ǵ� �̺�Ʈ.
        /// </summary>
        event Action OnStaminaChanged;

        /// <summary>
        /// ������Ʈ ���¸� �����մϴ�.
        /// </summary>
        /// <param name="isSprinting">������Ʈ ����</param>
        void SetIsSprinting(bool isSprinting);

        /// <summary>
        /// ���¹̳� ���� �߰��մϴ�.
        /// </summary>
        /// <param name="amount">�߰��� ���¹̳� ��</param>
        void AddStamina(float amount);
    }
}