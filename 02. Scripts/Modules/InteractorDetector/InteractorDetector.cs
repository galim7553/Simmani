using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GamePlay.Modules
{
    public class InteractorDetector : ModuleBase, IInteractorDetector, IUpdatable
    {
        IInteractorDectectorModel _model;
        Transform _rayOrigin;
        IInteractorMappable _interactorMappable;

        public event Action<IInteractor> OnInteractorDetected;
        public event Action OnInteractorMissed;

        RaycastHit _hit;
        public InteractorDetector(IInteractorDectectorModel model, Transform rayOrigin, IInteractorMappable interactorMappable)
        {
            _model = model;
            _rayOrigin = rayOrigin;
            _interactorMappable = interactorMappable;
        }

        public void OnUpdate()
        {
            DetectInteractorOnUpdate();
        }

        void DetectInteractorOnUpdate()
        {
            // _rayOrigin의 position에서 forward 방향으로 RayCast
            if (Physics.Raycast(_rayOrigin.position, _rayOrigin.forward, out _hit, _model.Config.RayDistance, _model.Config.InteractableLayerMask))
            {
                if (_interactorMappable.TryGetInteractor(_hit.collider, out var interactor))
                    OnInteractorDetected?.Invoke(interactor);
                else
                    OnInteractorMissed?.Invoke();
                return;
            }
            OnInteractorMissed?.Invoke();
        }

        public override void Clear()
        {
            base.Clear();

            OnInteractorDetected = null;
            OnInteractorMissed = null;
        }
    }

}

