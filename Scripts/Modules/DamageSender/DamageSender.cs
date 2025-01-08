using UnityEngine;

namespace GamePlay.Modules
{
    /// <summary>
    /// ������ ������ �����ϴ� Ŭ����.
    /// </summary>
    public class DamageSender : ModuleBase, IDamageSender
    {
        IDamageSenderModel _model;
        IDamageReceiverMappable _damageReceiverMappable;

        /// <summary>
        /// ������. ������ ���� �𵨰� ���۸� �ʱ�ȭ.
        /// </summary>
        /// <param name="model">������ ���� ��.</param>
        /// <param name="damageReceiverMappable">������ ������ ����.</param>
        public DamageSender(IDamageSenderModel model, IDamageReceiverMappable damageReceiverMappable)
        {
            _model = model;
            _damageReceiverMappable = damageReceiverMappable;
        }

        /// <summary>
        /// �浹ü(Collider)�� ���� ������ ������ ó��.
        /// </summary>
        /// <param name="collider">�浹�� Collider ��ü.</param>
        public void OnHit(Collider collider)
        {
            if (_damageReceiverMappable.TryGetDamageReceiver(collider, out var damageReceiver))
            {
                if (_model.GetIsDamageSendable(damageReceiver.CharacterTagType))
                {
                    damageReceiver.TakeDamage(_model.Damage);
                }
            }
                
        }

        /// <summary>
        /// ������ ������ ��ü�� ���� �����Ͽ� ������ ������ ó��.
        /// </summary>
        /// <param name="damageReceiver">������ ������ ��ü.</param>
        public void OnHit(IDamageReceiver damageReceiver)
        {
            if(_model.GetIsDamageSendable(damageReceiver.CharacterTagType))
                damageReceiver.TakeDamage(_model.Damage);
        }
    }
}
