using GamePlay.Configs;
using GamePlay.Datas;

namespace GamePlay.Hubs.Equipments
{
    /// <summary>
    /// 기어(Gear) 모델 구현 클래스.
    /// </summary>
    public class GearModel : EquipmentModel<GearConfig>, IGearModel
    {
        public GearModel(GearConfig config, ItemData itemData) : base(config, itemData)
        {
        }

        
    }
}

