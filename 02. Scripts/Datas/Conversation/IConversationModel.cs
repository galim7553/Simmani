using System.Collections.Generic;

namespace GamePlay.Datas
{
    /// <summary>
    /// 대화 모델 인터페이스. 대화 데이터를 제공하며 설정을 참조합니다.
    /// </summary>
    public interface IConversationModel
    {
        IConversationConfig Config { get; }

        /// <summary>
        /// 대화의 문장 리스트를 제공합니다.
        /// </summary>
        IReadOnlyList<string> Dialogues { get; }
    }
}
