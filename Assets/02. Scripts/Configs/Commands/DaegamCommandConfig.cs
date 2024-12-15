using System;
using System.Collections;
using System.Collections.Generic;
using GamePlay.Commands;
using UnityEngine;

namespace GamePlay.Configs
{
    [Serializable]
    public class DaegamCommandConfig : ConfigBase, IDaegamCommandConfig
    {
        [Header("----- 대감 명령 -----")]
        [SerializeField] string _greetingConversationKey = "DaeGam_1";
        [SerializeField] string _zeroConversationKey = "DaeGam_4";
        [SerializeField] string _lackConversationKey = "DaeGam_2";
        [SerializeField] string _clearConversationKey = "DaeGam_3";

        public string GreetingConversationKey => _greetingConversationKey;
        public string ZeroConversationKey => _zeroConversationKey;
        public string LackConversationKey => _lackConversationKey;
        public string ClearConversationKey => _clearConversationKey;
    }
}