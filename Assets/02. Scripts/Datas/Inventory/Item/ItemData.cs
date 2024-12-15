using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Datas
{
    [Serializable]
    public class ItemData
    {
        [SerializeField] string _key;
        [SerializeField] bool _hasEquipped;

        public string Key => _key;
        public bool HasEquipped => _hasEquipped;

        public event Action OnHasEquippedChanged;

        public ItemData(string key)
        {
            _key = key;
        }

        public void SetHasEquipped(bool hasEquipped)
        {
            _hasEquipped = hasEquipped;
            OnHasEquippedChanged?.Invoke();
        }
    }
}