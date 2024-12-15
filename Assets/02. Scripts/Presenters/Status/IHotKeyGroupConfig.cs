using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Presenters
{
    public interface IHotKeyGroupConfig
    {
        IReadOnlyList<HotKeyInfo> HotKeyInfos { get; }
    }

    [Serializable]
    public class HotKeyInfo
    {
        [SerializeField] string _targetItemKey = "Red_Potion";
        [SerializeField] string _spritePath = "Red";

        public string TargetItemKey => _targetItemKey;
        public string SpritePath => $"Sprites/Items/{_spritePath}";
    }
}


