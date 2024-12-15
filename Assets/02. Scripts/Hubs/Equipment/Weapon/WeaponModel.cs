using System.Collections;
using System.Collections.Generic;
using GamePlay.Configs;
using GamePlay.Datas;
using GamePlay.Modules;

namespace GamePlay.Hubs.Equipments
{
    public class WeaponModel : EquipmentModel<WeaponConfig>, IWeaponModel
    {
        public DamageSenderModel DamageSenderModel { get; private set; }
        public WeaponModel(WeaponConfig config, ItemData itemData) : base(config, itemData)
        {
            DamageSenderModel = new DamageSenderModel(config);
        }
    }
}


