namespace GamePlay.Modules
{
    /// <summary>
    /// ���� �������� �����ϴ� �������̽�.
    /// </summary>
    public interface IJumperConfig
    {
        /// <summary>
        /// ���� Ÿ�� (�ӵ� �Ǵ� ���� ����).
        /// </summary>
        IJumper.JumpType JumpType { get; }

        /// <summary>
        /// �⺻ ���� �ӵ�.
        /// </summary>
        float BaseJumpSpeed { get; }

        /// <summary>
        /// �⺻ ���� ����.
        /// </summary>
        float BaseJumpHeight { get; }
    }
}
