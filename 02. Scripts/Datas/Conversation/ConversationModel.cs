using System.Collections;
using System.Collections.Generic;
using GamePlay.Modules;
using UnityEngine;

namespace GamePlay.Datas
{
    public class ConversationModel : ModuleModelBase<IConversationConfig>, IConversationModel
    {
        string _text;
        string[] _dialogues;
        public IReadOnlyList<string> Dialogues => _dialogues;
        public ConversationModel(IConversationConfig config, string text) : base(config)
        {
            _text = text;

            _dialogues = _text.Split('\n');
        }
    }
}


