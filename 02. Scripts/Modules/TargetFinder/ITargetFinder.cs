using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Modules
{
    public interface ITargetFinder : IModule
    {
        IDamageReceiver FindTarget(float detectionLength);
        bool GetIsInHitSphere(IDamageReceiver target, float detectionLength);
        IReadOnlyList<IDamageReceiver> FindTargets(float detectionLength);
    }

}

