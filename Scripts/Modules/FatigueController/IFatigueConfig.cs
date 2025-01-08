namespace GamePlay.Modules
{
    /// <summary>
    /// �Ƿε� ���� ������ �����ϴ� �������̽�.
    /// </summary>
    public interface IFatigueConfig
    {
        /// <summary>
        /// �ʱ� �Ƿε� ��.
        /// </summary>
        float Fatigue { get; }

        /// <summary>
        /// �Ƿε� ���� �ӵ�(�ʴ� ���ҷ�).
        /// </summary>
        float FatigueConsumptionSpeed { get; }
    }
}


