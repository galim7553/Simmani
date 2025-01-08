namespace GamePlay.Modules
{
    /// <summary>
    /// ȸ�� ����� ���� �����͸� �����ϴ� �������̽�.
    /// </summary>
    public interface IRotatorConfig
    {
        /// <summary>
        /// �⺻ ȸ�� �ӵ�.
        /// </summary>
        float BaseRotSpeed { get; }

        /// <summary>
        /// ȸ�� ���� ������.
        /// </summary>
        RotatorLimiter RotatorLimiter { get; }
    }
}