using System.Collections.Generic;
using GamePlay.Modules;

namespace GamePlay.Datas
{
    /// <summary>
    /// ��ȭ ��. ������ ��ȭ �����͸� �����ϸ�, ��ȭ �ؽ�Ʈ�� �и��Ͽ� �����մϴ�.
    /// </summary>
    public class ConversationModel : ModuleModelBase<IConversationConfig>, IConversationModel
    {
        string _text;
        string[] _dialogues;
        public IReadOnlyList<string> Dialogues => _dialogues;

        /// <summary>
        /// ConversationModel ������. ������ ��ȭ �ؽ�Ʈ�� �޾� �ʱ�ȭ�մϴ�.
        /// </summary>
        /// <param name="config">��ȭ ���� ��ü</param>
        /// <param name="text">��ȭ �ؽ�Ʈ</param>
        public ConversationModel(IConversationConfig config, string text) : base(config)
        {
            _text = text;

            _dialogues = _text.Split('\n');
        }
    }
}


