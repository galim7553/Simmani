using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Configs
{
    [CreateAssetMenu(fileName = "ItemConfigs", menuName = "GameConfig/ItemConfigs")]
    public class ItemConfigsScriptableObject : ScriptableObject
    {
        [SerializeField] List<ItemConfig> _itemConfigs;
        public IReadOnlyList<ItemConfig> ItemConfigs => _itemConfigs;
    }
}


