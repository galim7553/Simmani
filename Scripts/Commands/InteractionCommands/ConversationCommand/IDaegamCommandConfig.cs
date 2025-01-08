using GamePlay.Commands;

namespace GamePlay.Configs
{
    /// <summary>
    /// �밨 ��� ���� �������̽�.
    /// </summary>
    public interface IDaegamCommandConfig : ICommandConfig
    {
        string GreetingConversationKey { get; }
        string ZeroConversationKey { get; }
        string LackConversationKey { get; }
        string ClearConversationKey { get; }

    }
}


