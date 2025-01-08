using System;
using System.Collections.Generic;
using GamePlay.Commands;
using UnityEngine;

namespace GamePlay.Configs
{
    /// <summary>
    /// ���� ��ɿ� ���� ������ �����ϴ� Ŭ�����Դϴ�.
    /// ���� �̸�, ��ȭ Ű, ������ Ű�� �����մϴ�.
    /// </summary>
    [Serializable]
    public class ShopCommandConfig : ConfigBase, IShopCommandConfig
    {
        [Header("----- ���� ��� -----")]
        [SerializeField] string _shopNameKey = "ShopWeapon";
        [SerializeField] string[] _greetingConversationKeys = new string[] { "ShopWeapon_1" };
        [SerializeField] string[] _itemKeys = new string[0];

        public string ShopNameKey => _shopNameKey;
        public IReadOnlyList<string> ConversationKeys => _greetingConversationKeys;
        public string[] ItemKeys => _itemKeys;
    }
}


