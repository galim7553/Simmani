namespace GamePlay.Modules.AI
{
    /// <summary>
    /// �� AI�� ������ �����ϴ� �������̽��Դϴ�.
    /// </summary>
    public interface IEnemyAI : IModule, ITargetFollowableAI, IAttackableAI
    {
        EnemyAIState State { get; }
    }
}


