using System;
using GamePlay.Hubs;
using UnityEngine;

namespace GamePlay.Modules
{
    /// <summary>
    /// �ǰ� �ý����� ������ �����ϴ� �������̽�.
    /// </summary>
    public interface IDamageReceiver : IModule
    {
        /// <summary>
        /// ������� ���� �� �߻��ϴ� �̺�Ʈ.
        /// </summary>
        event Action<float> OnDamaged;

        /// <summary>
        /// ĳ���Ͱ� ������� �� �߻��ϴ� �̺�Ʈ.
        /// </summary>
        event Action OnDead;

        /// <summary>
        /// ĳ������ Transform.
        /// </summary>
        Transform Transform { get; }

        /// <summary>
        /// ĳ������ Collider.
        /// </summary>
        Collider Collider { get; }

        /// <summary>
        /// ĳ���� �±� Ÿ��.
        /// </summary>
        CharacterTagType CharacterTagType { get; }

        /// <summary>
        /// ������� �޾� ó���մϴ�.
        /// </summary>
        void TakeDamage(float damage);
    }
}