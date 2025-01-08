using UnityEngine;

namespace GamePlay.Modules
{
    /// <summary>
    /// �������� �����ϴ� ����� �����ϴ� �������̽�.
    /// </summary>
    public interface IDamageSender : IModule
    {
        /// <summary>
        /// �浹ü(Collider)�� ���� ������ ������ ó��.
        /// </summary>
        /// <param name="collider">�浹�� Collider ��ü.</param>
        void OnHit(Collider collider);


        /// <summary>
        /// ������ ������ ��ü�� ���� �����Ͽ� ������ ������ ó��.
        /// </summary>
        /// <param name="damageReceiver">������ ������ ��ü.</param>
        void OnHit(IDamageReceiver damageReceiver);
    }
}


