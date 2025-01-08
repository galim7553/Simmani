namespace GamePlay.Modules
{
    /// <summary>
    /// ���� �����͸� �����ϴ� �������̽�.
    /// </summary>
    public interface IJumperModel
    {
        /// <summary>
        /// ���� Ÿ�� (�ӵ� �Ǵ� ���� ����).
        /// </summary>
        IJumper.JumpType JumpType { get; }

        /// <summary>
        /// ���� �ӵ�.
        /// </summary>
        float JumpSpeed { get; }

        /// <summary>
        /// ���� ����.
        /// </summary>
        float JumpHeight { get; }
    }
}
