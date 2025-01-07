using System;

namespace GamePlay.Modules
{
    /// <summary>
    /// 대화 플레이어 인터페이스.
    /// </summary>
    public interface IConversationPlayer
    {
        /// <summary>대화가 현재 진행 중인지 여부.</summary>
        bool IsPlaying { get; }


        /// <summary>대화가 완료되었을 때 호출되는 이벤트.</summary>
        event Action OnCompleted;

        /// <summary>
        /// 대화를 시작합니다.
        /// </summary>
        /// <param name="conversationKey">대화를 식별하는 키.</param>
        void StartConversation(string conversationKey);

        /// <summary>
        /// 대화를 중지합니다.
        /// </summary>
        void StopConversation();
        
    }

}
