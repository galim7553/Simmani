namespace GamePlay.Modules
{
    /// <summary>
    /// ���� ���ۿ� ���� ���� �������̽�.
    /// </summary>
    public interface IFollowerConfig
    {
        /// <summary>������Ʈ �ֱ�.</summary>
        float UpdateSpan { get; }

        /// <summary>�⺻ ȸ�� �ӵ�.</summary>
        float BaseAngularSpeed { get; }
    }
}


