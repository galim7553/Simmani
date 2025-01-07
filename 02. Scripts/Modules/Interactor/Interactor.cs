using System;
using UnityEngine;

namespace GamePlay.Modules
{

    /// <summary>
    /// 상호작용자(Interactor)의 기본 구현 클래스.
    /// </summary>
    public class Interactor : ModuleBase, IInteractor
    {
        public IInteractorModel Model { get; private set; }
        public Collider Collider { get; private set; }

        public event Action OnInteractionBegan;
        public event Action OnInteractionEnded;


        /// <summary>
        /// Interactor 생성자.
        /// </summary>
        /// <param name="model">Interactor 모델.</param>
        /// <param name="collider">상호작용 영역 콜라이더.</param>
        /// <param name="interactorMappable">Interactor를 매핑할 맵퍼.</param>
        public Interactor(IInteractorModel model, Collider collider, IInteractorMappable interactorMappable)
        {
            Model = model;
            Collider = collider;
            interactorMappable.AddInteractor(this);
        }

        public void BeginInteraction()
        {
            OnInteractionBegan?.Invoke();
        }

        public void EndInteraction()
        {
            OnInteractionEnded?.Invoke();
        }
    }
}


