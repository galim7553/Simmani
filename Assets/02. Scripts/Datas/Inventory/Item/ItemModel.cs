using GamePlay.Modules;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Datas
{
    public class ItemModel : DataDependantModelBase<IItemConfig, ItemData>, IItemModel
    {
        public ItemData Data => _data;
        public IItemUsage Usage { get; private set; }

        public bool HasEquipped => _data.HasEquipped;
        public event Action OnHasEquippedChanged;

        public ItemModel(IItemConfig config, ItemData data, IItemUsage usage = null) : base(config, data)
        {
            Usage = usage;

            _data.OnHasEquippedChanged += OnDataHasEquippedChanged;
        }

        void OnDataHasEquippedChanged()
        {
            OnHasEquippedChanged?.Invoke();
        }
    }
}


