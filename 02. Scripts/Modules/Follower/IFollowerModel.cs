namespace GamePlay.Modules
{
    /// <summary>
    /// ���� �� �������̽�.
    /// </summary>
    public interface IFollowerModel
    {
        IFollowerConfig Config { get; }

        /// <summary>���� �ӵ�.</summary>
        float Speed { get; }

        /// <summary>ȸ�� �ӵ�.</summary>
        float AngularSpeed { get; }
    }

}