using GamePlay.Configs;
using GamePlay.Datas;
using GamePlay.Modules;
using GamePlay.Commands;

namespace GamePlay.Hubs
{
    /// <summary>
    /// �÷��̾� ĳ����(Hero)�� ������ ���� �����մϴ�.
    /// </summary>
    public class HeroModel : HubModelBase<HeroConfig>, IHeroModel
    {
        HeroData _data;

        // ���, �ǰ�, �Ƿ�, ������Ʈ ���� ���� �𵨵�.
        public EquipperModel EquipperModel { get; private set; }
        public DamageReceiverModel DamageReceiverModel { get; private set; }
        public FatigueModel FatigueModel { get; private set; }
        public SprintableMoverModel SprintableMoverModel { get; private set; }

        /// <summary>
        /// HeroModel�� ������. Config�� Data�� �������� ���� �� �ʱ�ȭ.
        /// </summary>
        public HeroModel(HeroConfig config, HeroData data) : base(config)
        {
            _data = data;

            // Config�� �������� ���� �� �ʱ�ȭ
            EquipperModel = new EquipperModel(Config);
            DamageReceiverModel = new DamageReceiverModel(Config);
            FatigueModel = new FatigueModel(Config, _data.FatigueData);
            SprintableMoverModel = new SprintableMoverModel(Config, Config);
        }

        /// <summary>
        /// ��ȿ�� �˻� �̺�Ʈ�� ȣ��Ǿ��� �� ����Ǵ� ����.
        /// </summary>
        protected override void OnValidated()
        {
            EquipperModel.ResetEquipSlots();
        }

        /// <summary>
        /// HeroModel�� ����� �����մϴ�.
        /// </summary>
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