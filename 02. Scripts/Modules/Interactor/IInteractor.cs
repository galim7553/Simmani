using System;
using UnityEngine;

namespace GamePlay.Modules
{
    /// <summary>
    /// 상호작용자(Interactor) 인터페이스.
    /// </summary>
    public interface IInteractor : IModule
    {
        /// <summary>Interactor의 데이터 모델.</summary>
        IInteractorModel Model { get; }

        /// <summary>상호작용이 시작될 때 호출되는 이벤트.</summary>
        event Action OnInteractionBegan;

        /// <summary>상호작용이 종료될 때 호출되는 이벤트.</summary>
        event Action OnInteractionEnded;

        /// <summary>상호작용 영역을 나타내는 콜라이더.</summary>
        Collider Collider { get; }

        /// <summary>상호작용을 시작합니다.</summary>
        void BeginInteraction();

        /// <summary>상호작용을 종료합니다.</summary>
        void EndInteraction();
    }
}