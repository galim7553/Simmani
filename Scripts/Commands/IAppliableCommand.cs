namespace GamePlay.Commands
{
    /// <summary>
    /// Ư�� ��� ���� ������ ��� �������̽�.
    /// </summary>
    /// <typeparam name="T">����� ������ ��� Ÿ��.</typeparam>
    public interface IAppliableCommand<T> : ICommand
    {
        /// <summary>
        /// ��� ����� �����մϴ�.
        /// </summary>
        /// <param name="target">����� ������ ���.</param>
        void Apply(T target);


        /// <summary>
        /// ��󿡼� ����� �����մϴ�.
        /// </summary>
        /// <param name="target">����� ������ ���.</param>
        void Disapply(T target);
    }
}


