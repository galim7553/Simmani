using System;
using System.Collections.Generic;
using GamePlay.Configs;
using UnityEngine;

namespace GamePlay.Commands
{
    /// <summary>
    /// ��ȭ Ŀ�ǵ忡 ���� ������ �����ϴ� Ŭ�����Դϴ�.
    /// ��ȭ Ű ����� �����մϴ�.
    /// </summary>
    [Serializable]
    public class ConversationCommandConfig : ConfigBase, IConversationCommandConfig
    {
        [Header("----- ��ȭ Ŀ�ǵ� -----")]
        [SerializeField] string[] _conversationKeys = new string[] { "Hidden_1" };
        public IReadOnlyList<string> ConversationKeys => _conversationKeys;
    }
}