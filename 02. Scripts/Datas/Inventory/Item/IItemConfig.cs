using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Datas
{
    public interface IItemConfig
    {
        string Key { get; }
        ItemType ItemType { get; }
        bool IsUsable { get; }
        int Index { get; }
        string ItemNameKey { get; }
        string SpritePath { get; }
        string DescriptionKey { get; }
        int Price { get; }
        string UsageKey { get; }
    }
}


