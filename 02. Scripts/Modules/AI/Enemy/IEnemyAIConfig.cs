namespace GamePlay.Modules.AI
{
    /// <summary>
    /// 적 AI의 설정값을 정의하는 인터페이스입니다.
    /// </summary>
    public interface IEnemyAIConfig : IAIConfig
    {
        /// <summary>기본 이동 속력.</summary>
        float BaseSpeed { get; }

        /// <summary>Idle 상태에서 사용할 동작 키.</summary>
        string IdleBehaviourKey { get; }

        /// <summary>Trace 상태에서 사용할 동작 키.</summary>
        string TraceBehaviourKey {get; }

        /// <summary>Attacking 상태에서 사용할 동작 키.</summary>
        string AttackingBehaviourKey { get; }

        /// <summary>탐지 범위.</summary>
        float DetectionLength { get; }

        /// <summary>추적 범위.</summary>
        float TraceLength { get; }

        /// <summary>공격 범위.</summary>
        float AttackLength { get; }

        /// <summary>타격 범위 반지름.</summary>
        float HitSphereRadius { get; }
    }
}


