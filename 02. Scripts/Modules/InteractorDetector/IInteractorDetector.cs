using System;

namespace GamePlay.Modules
{
    /// <summary>
    /// 상호작용 감지기 인터페이스.
    /// </summary>
    public interface IInteractorDetector : IModule
    {
        /// <summary>상호작용 가능한 객체를 감지했을 때 호출되는 이벤트.</summary>
        event Action<IInteractor> OnInteractorDetected;

        /// <summary>상호작용 가능한 객체를 감지하지 못했을 때 호출되는 이벤트.</summary>
        event Action OnInteractorMissed;
    }
}


