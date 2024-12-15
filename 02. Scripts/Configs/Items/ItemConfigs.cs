using GamePlay.Datas;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GamePlay.Configs
{
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


