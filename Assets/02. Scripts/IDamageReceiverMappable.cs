using System.Collections;
using System.Collections.Generic;
using GamePlay.Modules;
using UnityEngine;

namespace GamePlay
{
    public interface IDamageReceiverMappable
    {
        void AddDamageReceiver(IDamageReceiver damageReceiver);
        void RemoveDamageReceiver(IDamageReceiver damageReceiver);
        bool TryGetDamageReceiver(Collider collider, out IDamageReceiver damageReceiver);
    }
}


