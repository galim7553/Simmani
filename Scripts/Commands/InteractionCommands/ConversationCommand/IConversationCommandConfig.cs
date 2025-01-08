using System.Collections.Generic;

namespace GamePlay.Commands
{
    /// <summary>
    /// ��ȭ ��� ���� �������̽�.
    /// </summary>
    public interface IConversationCommandConfig : ICommandConfig
    {
        /// <summary>��ȭ Ű ����Ʈ.</summary>
        IReadOnlyList<string> ConversationKeys { get; }
    }
}