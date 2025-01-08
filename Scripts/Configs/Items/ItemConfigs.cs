using GamePlay.Datas;
using System;
using UnityEngine;


namespace GamePlay.Configs
{
    /// <summary>
    /// 아이템의 설정 데이터를 정의하는 클래스.
    /// 각 아이템은 타입, 가격, 이름, 스프라이트 경로, 설명 등을 포함합니다.
    /// </summary>
    [Serializable]
    public class ItemConfig : ConfigBase, IItemConfig
    {
        [SerializeField] ItemType _itemType = ItemType.Sansam;
        [SerializeField] int _index = 410;
        [SerializeField] string _itemNameKey = "SanSam_Name";
        [SerializeField] string _spritePath = "SanSam";
        [SerializeField] string _descriptionKey = "SanSam_Info";
        [SerializeField] int _price = 100;
        [SerializeField] string _usageKey = string.Empty;

        public ItemType ItemType => _itemType;
        public bool IsUsable => _itemType == ItemType.Consumable || _itemType == ItemType.Equipment;
        public int Index => _index;
        public string ItemNameKey => _itemNameKey;
        public string SpritePath => $"Sprites/Items/{_spritePath}";
        public string DescriptionKey => _descriptionKey;
        public int Price => _price;
        public string UsageKey => _usageKey;

        public ItemConfig()
        {
            _key = "SanSam";
        }
    }
}


