using System.Collections;
using System.Collections.Generic;
using GamePlay.Datas;
using UnityEngine;

namespace GamePlay.Modules
{
    public interface IInventoryController
    {
        bool IsActive { get; }
        void ToggleInventory();
        void DisplayInventory(bool isVisible, IShopModel shopModel);
    }
}


