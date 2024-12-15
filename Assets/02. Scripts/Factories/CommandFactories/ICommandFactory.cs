using GamePlay.Commands;

namespace GamePlay.Factories
{
    public interface ICommandFactory
    {
        ICommand CreateCommand(string key);
    }
}


