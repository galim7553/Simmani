using GamePlay.Configs;
using GamePlay.Datas;
using GamePlay.Modules;

namespace GamePlay.Hubs.Equipments
{
    /// <summary>
    /// 무기 모델 클래스. DamageSender 모델을 포함.
    /// </summary>
    public class WeaponModel : EquipmentModel<WeaponConfig>, IWeaponModel
    {
        /// <summary>
        /// 무기의 DamageSender 모델.
        /// </summary>
        public DamageSenderModel DamageSenderModel { get; private set; }
        public WeaponModel(WeaponConfig config, ItemData itemData) : base(config, itemData)
        {
            DamageSenderModel = new DamageSenderModel(config);
        }
    }
}


