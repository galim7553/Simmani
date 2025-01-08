using GamePlay.Commands;

namespace GamePlay.Factories
{
    /// <summary>
    /// 명령(Command)을 생성하는 팩토리 인터페이스.
    /// </summary>
    public interface ICommandFactory
    {
        /// <summary>
        /// 주어진 키를 기반으로 명령(Command)을 생성합니다.
        /// </summary>
        /// <param name="key">명령의 키 값.</param>
        /// <returns>생성된 명령 객체.</returns>
        ICommand CreateCommand(string key);
    }
}


