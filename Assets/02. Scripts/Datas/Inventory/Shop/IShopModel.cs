using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Datas
{
    public interface IShopModel
    {
        IShopConfig Config { get; }
        IReadOnlyList<IItemModel> ItemModels { get; }
    }
}


