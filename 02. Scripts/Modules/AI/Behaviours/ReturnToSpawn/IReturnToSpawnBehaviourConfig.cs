namespace GamePlay.Modules.AI
{
    /// <summary>
    /// ���� ��ġ�� �����ϴ� �ൿ�� �������� �����ϴ� �������̽��Դϴ�.
    /// </summary>
    public interface IReturnToSpawnBehaviourConfig : IBehaviourConfig
    {
        float SpeedRatio { get; }
    }
}