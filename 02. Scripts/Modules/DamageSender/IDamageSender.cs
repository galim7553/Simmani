using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Modules
{
    public interface IDamageSender : IModule
    {
        void OnHit(Collider collider);
        void OnHit(IDamageReceiver damageReceiver);
    }
}


