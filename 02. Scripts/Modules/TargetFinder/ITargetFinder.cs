using System.Collections.Generic;

namespace GamePlay.Modules
{
    /// <summary>
    /// 타겟 탐지 모듈 인터페이스.
    /// </summary>
    public interface ITargetFinder : IModule
    {
        /// <summary>탐지 범위 내에서 가장 우선순위가 높은 타겟을 찾음.</summary>
        IDamageReceiver FindTarget(float detectionLength);

        /// <summary>지정된 타겟이 히트 스피어 내에 있는지 확인.</summary>
        bool GetIsInHitSphere(IDamageReceiver target, float detectionLength);

        /// <summary>탐지 범위 내 모든 타겟을 찾음.</summary>
        IReadOnlyList<IDamageReceiver> FindTargets(float detectionLength);
    }

}

