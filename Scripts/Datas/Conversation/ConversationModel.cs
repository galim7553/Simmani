using System.Collections.Generic;
using GamePlay.Modules;

namespace GamePlay.Datas
{
    /// <summary>
    /// 대화 모델. 설정과 대화 데이터를 관리하며, 대화 텍스트를 분리하여 제공합니다.
    /// </summary>
    public class ConversationModel : ModuleModelBase<IConversationConfig>, IConversationModel
    {
        string _text;
        string[] _dialogues;
        public IReadOnlyList<string> Dialogues => _dialogues;

        /// <summary>
        /// ConversationModel 생성자. 설정과 대화 텍스트를 받아 초기화합니다.
        /// </summary>
        /// <param name="config">대화 설정 객체</param>
        /// <param name="text">대화 텍스트</param>
        public ConversationModel(IConversationConfig config, string text) : base(config)
        {
            _text = text;

            _dialogues = _text.Split('\n');
        }
    }
}


