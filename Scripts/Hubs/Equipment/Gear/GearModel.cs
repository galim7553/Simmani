using GamePlay.Configs;
using GamePlay.Datas;

namespace GamePlay.Hubs.Equipments
{
    /// <summary>
    /// ���(Gear) �� ���� Ŭ����.
    /// </summary>
    public class GearModel : EquipmentModel<GearConfig>, IGearModel
    {
        public GearModel(GearConfig config, ItemData itemData) : base(config, itemData)
        {
        }

        
    }
}

