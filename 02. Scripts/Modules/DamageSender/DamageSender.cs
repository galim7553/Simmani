using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Modules
{
    public class DamageSender : ModuleBase, IDamageSender
    {
        IDamageSenderModel _model;
        IDamageReceiverMappable _damageReceiverMappable;


        

        public DamageSender(IDamageSenderModel model, IDamageReceiverMappable damageReceiverMappable)
        {
            _model = model;
            _damageReceiverMappable = damageReceiverMappable;
        }

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
        public void OnHit(IDamageReceiver damageReceiver)
        {
            if(_model.GetIsDamageSendable(damageReceiver.CharacterTagType))
                damageReceiver.TakeDamage(_model.Damage);
        }
    }
}
