using System;
using System.Collections;
using System.Collections.Generic;
using GamePlay.Configs;
using UnityEngine;

namespace GamePlay.Commands
{
    [Serializable]
    public class ConversationCommandConfig : ConfigBase, IConversationCommandConfig
    {
        [Header("----- ��ȭ Ŀ�ǵ� -----")]
        [SerializeField] string[] _conversationKeys = new string[] { "Hidden_1" };
        public IReadOnlyList<string> ConversationKeys => _conversationKeys;
    }
}