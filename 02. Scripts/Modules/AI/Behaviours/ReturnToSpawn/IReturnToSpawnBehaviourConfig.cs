namespace GamePlay.Modules.AI
{
    /// <summary>
    /// 스폰 위치로 복귀하는 행동의 설정값을 정의하는 인터페이스입니다.
    /// </summary>
    public interface IReturnToSpawnBehaviourConfig : IBehaviourConfig
    {
        float SpeedRatio { get; }
    }
}