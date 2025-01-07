using GamePlay.Commands;

namespace GamePlay.Configs
{
    /// <summary>
    /// 대감 명령 설정 인터페이스.
    /// </summary>
    public interface IDaegamCommandConfig : ICommandConfig
    {
        string GreetingConversationKey { get; }
        string ZeroConversationKey { get; }
        string LackConversationKey { get; }
        string ClearConversationKey { get; }

    }
}


