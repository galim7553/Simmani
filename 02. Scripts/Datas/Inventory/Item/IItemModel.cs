using GamePlay.Modules;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Datas
{
    public enum ItemType
    {
        Sansam,
        Sellable,
        Equipment,
        Consumable,
        Passive,
    }
    public interface IItemModel
    {
        ItemData Data { get; }
        bool HasEquipped { get; }
        IItemConfig Config { get; }
        IItemUsage Usage { get; }
        event Action OnHasEquippedChanged;
    }

}

