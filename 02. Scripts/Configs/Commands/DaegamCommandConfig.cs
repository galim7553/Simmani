using System;
using UnityEngine;

namespace GamePlay.Configs
{
    /// <summary>
    /// �밨 ��ɿ� ���� ������ �����ϴ� Ŭ�����Դϴ�.
    /// ��ȭ Ű�� ������ ��� ���� ������ �����մϴ�.
    /// </summary>
    [Serializable]
    public class DaegamCommandConfig : ConfigBase, IDaegamCommandConfig
    {
        [Header("----- �밨 ��� -----")]
        [SerializeField] string _greetingConversationKey = "DaeGam_1"; // �λ� ��ȭ Ű
        [SerializeField] string _zeroConversationKey = "DaeGam_4"; // ��� ���� ��ȭ Ű
        [SerializeField] string _lackConversationKey = "DaeGam_2"; // ��� ���� ��ȭ Ű
        [SerializeField] string _clearConversationKey = "DaeGam_3"; // ��� ���� �Ϸ� ��ȭ Ű

        public string GreetingConversationKey => _greetingConversationKey;
        public string ZeroConversationKey => _zeroConversationKey;
        public string LackConversationKey => _lackConversationKey;
        public string ClearConversationKey => _clearConversationKey;
    }
}