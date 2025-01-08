using System;
using UnityEngine;


namespace GamePlay.Modules
{
    /// <summary>
    /// 상호작용 감지기 기본 구현 클래스.
    /// </summary>
    public class InteractorDetector : ModuleBase, IInteractorDetector, IUpdatable
    {
        IInteractorDectectorModel _model;
        Transform _rayOrigin;
        IInteractorMappable _interactorMappable;

        public event Action<IInteractor> OnInteractorDetected;
        public event Action OnInteractorMissed;

        RaycastHit _hit;

        /// <summary>
        /// InteractorDetector 생성자.
        /// </summary>
        /// <param name="model">감지기의 설정값과 모델.</param>
        /// <param name="rayOrigin">레이가 시작되는 Transform.</param>
        /// <param name="interactorMappable">Interactor를 매핑하는 맵퍼.</param>
        public InteractorDetector(IInteractorDectectorModel model, Transform rayOrigin, IInteractorMappable interactorMappable)
        {
            _model = model;
            _rayOrigin = rayOrigin;
            _interactorMappable = interactorMappable;
        }

        /// <summary>
        /// 매 프레임 호출되어 상호작용 가능한 객체를 감지합니다.
        /// </summary>
        public void OnUpdate()
        {
            DetectInteractorOnUpdate();
        }

        /// <summary>
        /// 레이를 발사하여 상호작용 가능한 객체를 감지합니다.
        /// </summary>
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

