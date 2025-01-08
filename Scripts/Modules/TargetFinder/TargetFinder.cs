using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Modules
{
    /// <summary>
    /// Å¸°Ù Å½Áö ¸ðµâ ±¸Çö.
    /// </summary>
    public class TargetFinder : ModuleBase, ITargetFinder
    {
        ITargetFinderModel _model;
        Transform _transform;
        Collider _collider;
        IDamageReceiverMappable _damageReceiverMappable;
        Transform _hitSphereCenter;

        Collider[] _colliders;
        List<IDamageReceiver> _damageReceivers;

        /// <summary>
        /// Å¸°Ù Å½Áö ¸ðµâ »ý¼ºÀÚ.
        /// </summary>
        public TargetFinder(ITargetFinderModel model, Transform transform, Collider collider,
            IDamageReceiverMappable damageReceiverMappable, Transform hitSphereCenter)
        {
            _model = model;
            _transform = transform;
            _collider = collider;
            _damageReceiverMappable = damageReceiverMappable;
            _hitSphereCenter = hitSphereCenter;

            _colliders = new Collider[model.Config.DetectionCountLimit];
            _damageReceivers = new List<IDamageReceiver>(model.Config.DetectionCountLimit);
            
        }

        public IDamageReceiver FindTarget(float detectionLength)
        {
            _damageReceivers.Clear();
            int count = Physics.OverlapSphereNonAlloc(_transform.position, detectionLength, _colliders, _model.Config.TargetLayerMask, QueryTriggerInteraction.Collide);

            for(int i = 0; i < count; i++)
            {
                Collider collider = _colliders[i];
                if (collider == null || _collider == collider) continue;
                if (_damageReceiverMappable.TryGetDamageReceiver(collider, out var damageReceiver))
                {
                    if (_model.GetIsTargetTag(damageReceiver.CharacterTagType))
                        _damageReceivers.Add(damageReceiver);
                }
            }

            if(_damageReceivers.Count > 0)
            {
                _damageReceivers.Sort(CompareDamageReceiverPriority);
                return _damageReceivers[0];
            }
            return null;
        }

        public IReadOnlyList<IDamageReceiver> FindTargets(float detectionLength)
        {
            _damageReceivers.Clear();
            int count = Physics.OverlapSphereNonAlloc(_transform.position, detectionLength, _colliders, _model.Config.TargetLayerMask, QueryTriggerInteraction.Collide);

            for(int i = 0; i < count; i++)
            {
                Collider collider = _colliders[i];
                if (collider == null || _collider == collider) continue;
                if (_damageReceiverMappable.TryGetDamageReceiver(collider, out var damageReceiver))
                {
                    if (_model.GetIsTargetTag(damageReceiver.CharacterTagType))
                        _damageReceivers.Add(damageReceiver);
                }
            }
            if(_damageReceivers.Count > 0)
                _damageReceivers.Sort(CompareDamageReceiverPriority);
            return _damageReceivers;
        }

        public bool GetIsInHitSphere(IDamageReceiver target, float detectionLength)
        {
            int count = Physics.OverlapSphereNonAlloc(_hitSphereCenter.position, detectionLength, _colliders, _model.Config.TargetLayerMask, QueryTriggerInteraction.Collide);

            for(int i = 0; i < count; i++)
            {
                Collider collider = _colliders[i];
                if (collider == null || _collider == collider) continue;
                if (_damageReceiverMappable.TryGetDamageReceiver(collider, out var damageReceiver))
                {
                    if (damageReceiver == target)
                        return true;
                }
            }
            return false;
        }

        int CompareDamageReceiverPriority(IDamageReceiver a, IDamageReceiver b)
        {
            int aPriority = _model.GetTagPriority(a.CharacterTagType);
            int bPriority = _model.GetTagPriority(b.CharacterTagType);

            if (aPriority != bPriority)
                return aPriority.CompareTo(bPriority);

            float aDist = Vector3.Distance(_transform.position, a.Transform.position);
            float bDist = Vector3.Distance(_transform.position, b.Transform.position);
            return aDist.CompareTo(bDist);
        }


        public override void Clear()
        {
            base.Clear();

            _damageReceivers.Clear();
        }
    }

}

