using System;
using System.Collections.Generic;
using GamePlay.Commands;
using UnityEngine;

namespace GamePlay.Configs
{
    /// <summary>
    /// 상점 명령에 대한 설정을 정의하는 클래스입니다.
    /// 상점 이름, 대화 키, 아이템 키를 포함합니다.
    /// </summary>
    [Serializable]
    public class ShopCommandConfig : ConfigBase, IShopCommandConfig
    {
        [Header("----- 상점 명령 -----")]
        [SerializeField] string _shopNameKey = "ShopWeapon";
        [SerializeField] string[] _greetingConversationKeys = new string[] { "ShopWeapon_1" };
        [SerializeField] string[] _itemKeys = new string[0];

        public string ShopNameKey => _shopNameKey;
        public IReadOnlyList<string> ConversationKeys => _greetingConversationKeys;
        public string[] ItemKeys => _itemKeys;
    }
}


