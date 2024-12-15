using System.Collections;
using System.Collections.Generic;
using GamePlay.Configs;
using GamePlay.Datas;
using UnityEngine;

namespace GamePlay.Hubs.Equipments
{
    public abstract class EquipmentModel<T> : HubModelBase<T>, IEquipmentModel where T : EquipmentConfig
    {
        EquipmentConfig IEquipmentModel.Config => Config;
        ItemData _data;

        public bool HasEquipped => _data.HasEquipped;
        public EquipmentModel(T config, ItemData itemData) : base(config)
        {
            _data = itemData;
        }
        public void SetHasEquipped(bool hasEquipped)
        {
            _data.SetHasEquipped(hasEquipped);
        }
    }
}


