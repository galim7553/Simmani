using System;
using UnityEngine;


namespace GamePlay.Modules
{
    /// <summary>
    /// ��ȣ�ۿ� ������ �⺻ ���� Ŭ����.
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
        /// InteractorDetector ������.
        /// </summary>
        /// <param name="model">�������� �������� ��.</param>
        /// <param name="rayOrigin">���̰� ���۵Ǵ� Transform.</param>
        /// <param name="interactorMappable">Interactor�� �����ϴ� ����.</param>
        public InteractorDetector(IInteractorDectectorModel model, Transform rayOrigin, IInteractorMappable interactorMappable)
        {
            _model = model;
            _rayOrigin = rayOrigin;
            _interactorMappable = interactorMappable;
        }

        /// <summary>
        /// �� ������ ȣ��Ǿ� ��ȣ�ۿ� ������ ��ü�� �����մϴ�.
        /// </summary>
        public void OnUpdate()
        {
            DetectInteractorOnUpdate();
        }

        /// <summary>
        /// ���̸� �߻��Ͽ� ��ȣ�ۿ� ������ ��ü�� �����մϴ�.
        /// </summary>
        void DetectInteractorOnUpdate()
        {
            // _rayOrigin�� position���� forward �������� RayCast
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

