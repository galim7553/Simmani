using GamePlay.Configs;
using GamePlay.Datas;
using GamePlay.Modules;

namespace GamePlay.Hubs.Equipments
{
    /// <summary>
    /// ���� �� Ŭ����. DamageSender ���� ����.
    /// </summary>
    public class WeaponModel : EquipmentModel<WeaponConfig>, IWeaponModel
    {
        /// <summary>
        /// ������ DamageSender ��.
        /// </summary>
        public DamageSenderModel DamageSenderModel { get; private set; }
        public WeaponModel(WeaponConfig config, ItemData itemData) : base(config, itemData)
        {
            DamageSenderModel = new DamageSenderModel(config);
        }
    }
}


