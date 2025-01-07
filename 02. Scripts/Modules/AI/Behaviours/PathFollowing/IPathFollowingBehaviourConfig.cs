namespace GamePlay.Modules.AI
{
    /// <summary>
    /// 경로 추적 행동 설정값을 정의하는 인터페이스입니다.
    /// </summary>
    public interface IPathFollowingBehaviourConfig : IBehaviourConfig
    {
        public enum LoopType
        {
            FowardLoop,
            PingPongLoop
        }

        /// <summary>경로 반복 유형입니다.</summary>
        public LoopType Type { get; }

        /// <summary>속도 비율입니다.</summary>
        public float SpeedRatio { get; }

        /// <summary>브레이크 거리입니다.</summary>
        public float BrakingDistance { get; }
    }
}