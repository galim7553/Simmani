using GamePlay.Configs;
using GamePlay.Datas;

namespace GamePlay.Hubs.Equipments
{
    public interface IEquipmentModel : IItemUsage
    {
        EquipmentConfig Config { get; }
        bool HasEquipped { get; }

        public void SetHasEquipped(bool hasEquipped);
    }

}

