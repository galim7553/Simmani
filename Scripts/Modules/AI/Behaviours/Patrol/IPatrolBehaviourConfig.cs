namespace GamePlay.Modules.AI
{
    /// <summary>
    /// 순찰 행동에 대한 설정값을 정의하는 인터페이스입니다.
    /// </summary>
    public interface IPatrolBehaviourConfig : IBehaviourConfig
    {
        /// <summary>순찰 반경 최소값.</summary>
        float MinRadius { get; }

        /// <summary>순찰 반경 최대값.</summary>
        float MaxRadius { get; }

        /// <summary>순찰 대기 시간 최소값(초).</summary>
        float MinSpan { get; }

        /// <summary>순찰 대기 시간 최대값(초).</summary>
        float MaxSpan { get; }

        /// <summary>순찰 중 속도 비율.</summary>
        float SpeedRatio { get; }
    }
}