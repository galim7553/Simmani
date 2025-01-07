using System.Collections.Generic;

namespace GamePlay.Commands
{
    /// <summary>
    /// 대화 명령 설정 인터페이스.
    /// </summary>
    public interface IConversationCommandConfig : ICommandConfig
    {
        /// <summary>대화 키 리스트.</summary>
        IReadOnlyList<string> ConversationKeys { get; }
    }
}