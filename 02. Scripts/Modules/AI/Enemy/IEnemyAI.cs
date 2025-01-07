namespace GamePlay.Modules.AI
{
    /// <summary>
    /// 적 AI의 동작을 정의하는 인터페이스입니다.
    /// </summary>
    public interface IEnemyAI : IModule, ITargetFollowableAI, IAttackableAI
    {
        EnemyAIState State { get; }
    }
}


