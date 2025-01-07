namespace GamePlay.Modules.AI
{
    /// <summary>
    /// 적 AI의 데이터 모델 인터페이스입니다.
    /// </summary>
    public interface IEnemyAIModel : IFollowableAIModel
    {
        IEnemyAIConfig Config { get; }

    }
}


