using System;
using GamePlay.Configs;
using GamePlay.Datas;
using GamePlay.Modules;
using GamePlay.Commands;

namespace GamePlay.Hubs
{
    public class HeroModel : HubModelBase<HeroConfig>, IHeroModel
    {
        HeroData _data;
        public EquipperModel EquipperModel { get; private set; }
        public DamageReceiverModel DamageReceiverModel { get; private set; }
        public FatigueModel FatigueModel { get; private set; }
        public SprintableMoverModel SprintableMoverModel { get; private set; }

        public HeroModel(HeroConfig config, HeroData data) : base(config)
        {
            _data = data;

            EquipperModel = new EquipperModel(Config);
            DamageReceiverModel = new DamageReceiverModel(Config);
            FatigueModel = new FatigueModel(Config, _data.FatigueData);
            SprintableMoverModel = new SprintableMoverModel(Config, Config);
        }

        protected override void OnValidated()
        {
            EquipperModel.ResetEquipSlots();
        }

        void IHeroModel.ExecuteCommand(IHeroModelCommandConfig.CommandType commandType, float amount)
        {
            switch (commandType)
            {
                case IHeroModelCommandConfig.CommandType.HealHealth:
                    DamageReceiverModel.AddHealth(amount);
                    break;
                case IHeroModelCommandConfig.CommandType.HealStamina:
                    SprintableMoverModel.AddStamina(amount);
                    break;
                case IHeroModelCommandConfig.CommandType.HealFatigue:
                    FatigueModel.AddFatigue(amount);
                    break;
                case IHeroModelCommandConfig.CommandType.AddMaxHealth:
                    DamageReceiverModel.AddBonusHealth(amount);
                    break;
                case IHeroModelCommandConfig.CommandType.AddMaxStamina:
                    SprintableMoverModel.AddBonusStamina(amount);
                    break;
                case IHeroModelCommandConfig.CommandType.AddMaxFatigue:
                    FatigueModel.AddBonusFatigue(amount);
                    break;
            }
        }
    }

}