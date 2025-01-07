namespace GamePlay.Modules
{
    /// <summary>
    /// ȸ�� ����� ��Ÿ�� �����͸� �����ϴ� �������̽�.
    /// </summary>
    public interface IRotatorModel
    {
        /// <summary>
        /// ȸ�� �ӵ�.
        /// </summary>
        float RotSpeed { get; }

        /// <summary>
        /// ȸ�� ���� ������.
        /// </summary>
        RotatorLimiter RotatorLimiter { get; }
    }
}