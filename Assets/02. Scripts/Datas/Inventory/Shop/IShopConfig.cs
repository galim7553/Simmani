using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Datas
{
    public interface IShopConfig
    {
        string ShopNameKey { get; }
        string[] ItemKeys { get; }
    }
}


