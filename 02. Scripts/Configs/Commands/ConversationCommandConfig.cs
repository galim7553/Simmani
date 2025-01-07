using System;
using System.Collections.Generic;
using GamePlay.Configs;
using UnityEngine;

namespace GamePlay.Commands
{
    /// <summary>
    /// 대화 커맨드에 대한 설정을 정의하는 클래스입니다.
    /// 대화 키 목록을 제공합니다.
    /// </summary>
    [Serializable]
    public class ConversationCommandConfig : ConfigBase, IConversationCommandConfig
    {
        [Header("----- 대화 커맨드 -----")]
        [SerializeField] string[] _conversationKeys = new string[] { "Hidden_1" };
        public IReadOnlyList<string> ConversationKeys => _conversationKeys;
    }
}