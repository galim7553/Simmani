namespace GamePlay.Modules.AI
{
    /// <summary>
    /// �� AI�� ������ �� �������̽��Դϴ�.
    /// </summary>
    public interface IEnemyAIModel : IFollowableAIModel
    {
        IEnemyAIConfig Config { get; }

    }
}


