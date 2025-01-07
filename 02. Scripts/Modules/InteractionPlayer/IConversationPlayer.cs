using System;

namespace GamePlay.Modules
{
    /// <summary>
    /// ��ȭ �÷��̾� �������̽�.
    /// </summary>
    public interface IConversationPlayer
    {
        /// <summary>��ȭ�� ���� ���� ������ ����.</summary>
        bool IsPlaying { get; }


        /// <summary>��ȭ�� �Ϸ�Ǿ��� �� ȣ��Ǵ� �̺�Ʈ.</summary>
        event Action OnCompleted;

        /// <summary>
        /// ��ȭ�� �����մϴ�.
        /// </summary>
        /// <param name="conversationKey">��ȭ�� �ĺ��ϴ� Ű.</param>
        void StartConversation(string conversationKey);

        /// <summary>
        /// ��ȭ�� �����մϴ�.
        /// </summary>
        void StopConversation();
        
    }

}
