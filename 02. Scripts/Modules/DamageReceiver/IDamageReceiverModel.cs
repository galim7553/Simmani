using System;

namespace GamePlay.Modules
{
    /// <summary>
    /// �ǰ� �����͸� �����ϴ� �������̽�.
    /// </summary>
    public interface IDamageReceiverModel
    {
        IDamageReceiverConfig Config { get; }

        /// <summary>
        /// ü���� ����� �� �߻��ϴ� �̺�Ʈ.
        /// </summary>
        event Action OnHealthChanged;

        /// <summary>
        /// ĳ���Ͱ� ������� �� �߻��ϴ� �̺�Ʈ.
        /// </summary>
        event Action OnDead;

        /// <summary>
        /// �ִ� ü��.
        /// </summary>
        float MaxHealth { get; }

        /// <summary>
        /// ���� ü��.
        /// </summary>
        float Health { get; }

        /// <summary>
        /// ������� �޾� ü���� ���ҽ�ŵ�ϴ�.
        /// </summary>
        void TakeDamage(float damage);

        /// <summary>
        /// ü���� ȸ����ŵ�ϴ�.
        /// </summary>
        void AddHealth(float health);
    }
}
