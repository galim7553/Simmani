namespace GamePlay.Modules.AI
{
    /// <summary>
    /// 추적 행동의 설정값을 정의하는 인터페이스입니다.
    /// </summary>
    public interface ITraceBehaviourConfig : IBehaviourConfig
    {
        float SpeedRatio { get; }
    }
}