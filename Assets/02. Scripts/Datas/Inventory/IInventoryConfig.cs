using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Datas
{
    public interface IInventoryConfig
    {
        int SlotLimit { get; }
        string ItemOnInventoryViewPrefabPath { get; }

        string UseButtonTextKey { get; }
        string UnuseButtonTextKey { get; }
        string DumpButtonTextKey { get; }

        string SellGuideTextKey { get; }
        string BuyGuideTextKey { get; }
        string NotEnoughGoldTextKey { get; }
        string NotEnoughtSlotTextKey { get; }
    }
}


