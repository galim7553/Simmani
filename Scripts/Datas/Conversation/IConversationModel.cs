using System.Collections.Generic;

namespace GamePlay.Datas
{
    /// <summary>
    /// ��ȭ �� �������̽�. ��ȭ �����͸� �����ϸ� ������ �����մϴ�.
    /// </summary>
    public interface IConversationModel
    {
        IConversationConfig Config { get; }

        /// <summary>
        /// ��ȭ�� ���� ����Ʈ�� �����մϴ�.
        /// </summary>
        IReadOnlyList<string> Dialogues { get; }
    }
}
