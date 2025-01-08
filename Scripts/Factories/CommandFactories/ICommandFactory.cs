using GamePlay.Commands;

namespace GamePlay.Factories
{
    /// <summary>
    /// ���(Command)�� �����ϴ� ���丮 �������̽�.
    /// </summary>
    public interface ICommandFactory
    {
        /// <summary>
        /// �־��� Ű�� ������� ���(Command)�� �����մϴ�.
        /// </summary>
        /// <param name="key">����� Ű ��.</param>
        /// <returns>������ ��� ��ü.</returns>
        ICommand CreateCommand(string key);
    }
}


