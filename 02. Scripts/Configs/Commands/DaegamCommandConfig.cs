using System;
using UnityEngine;

namespace GamePlay.Configs
{
    /// <summary>
    /// 대감 명령에 대한 설정을 정의하는 클래스입니다.
    /// 대화 키를 포함한 명령 관련 설정을 제공합니다.
    /// </summary>
    [Serializable]
    public class DaegamCommandConfig : ConfigBase, IDaegamCommandConfig
    {
        [Header("----- 대감 명령 -----")]
        [SerializeField] string _greetingConversationKey = "DaeGam_1"; // 인사 대화 키
        [SerializeField] string _zeroConversationKey = "DaeGam_4"; // 산삼 없음 대화 키
        [SerializeField] string _lackConversationKey = "DaeGam_2"; // 산삼 부족 대화 키
        [SerializeField] string _clearConversationKey = "DaeGam_3"; // 산삼 제출 완료 대화 키

        public string GreetingConversationKey => _greetingConversationKey;
        public string ZeroConversationKey => _zeroConversationKey;
        public string LackConversationKey => _lackConversationKey;
        public string ClearConversationKey => _clearConversationKey;
    }
}