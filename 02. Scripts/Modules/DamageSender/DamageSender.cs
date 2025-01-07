using UnityEngine;

namespace GamePlay.Modules
{
    /// <summary>
    /// 데미지 송출을 구현하는 클래스.
    /// </summary>
    public class DamageSender : ModuleBase, IDamageSender
    {
        IDamageSenderModel _model;
        IDamageReceiverMappable _damageReceiverMappable;

        /// <summary>
        /// 생성자. 데미지 송출 모델과 맵퍼를 초기화.
        /// </summary>
        /// <param name="model">데미지 송출 모델.</param>
        /// <param name="damageReceiverMappable">데미지 수신자 맵퍼.</param>
        public DamageSender(IDamageSenderModel model, IDamageReceiverMappable damageReceiverMappable)
        {
            _model = model;
            _damageReceiverMappable = damageReceiverMappable;
        }

        /// <summary>
        /// 충돌체(Collider)를 통해 데미지 송출을 처리.
        /// </summary>
        /// <param name="collider">충돌한 Collider 객체.</param>
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
        /// 데미지 수신자 객체를 직접 지정하여 데미지 송출을 처리.
        /// </summary>
        /// <param name="damageReceiver">데미지 수신자 객체.</param>
        public void OnHit(IDamageReceiver damageReceiver)
        {
            if(_model.GetIsDamageSendable(damageReceiver.CharacterTagType))
                damageReceiver.TakeDamage(_model.Damage);
        }
    }
}
