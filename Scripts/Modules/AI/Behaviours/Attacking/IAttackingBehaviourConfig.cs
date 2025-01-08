namespace GamePlay.Modules.AI
{
    /// <summary>
    /// 공격 행동에 대한 설정값을 정의하는 인터페이스입니다.
    /// </summary>
    public interface IAttackingBehaviourConfig : IBehaviourConfig
    {
        /// <summary>공격 간격(초)입니다.</summary>
        float Span { get; }

        /// <summary>공격 가능 각도 범위(도)입니다.</summary>
        float AngleThreshold { get; }

        /// <summary>공격 중 회전 속도입니다.</summary>
        float RotSpeed { get; }
    }
}


