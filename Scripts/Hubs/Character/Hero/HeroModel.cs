using GamePlay.Configs;
using GamePlay.Datas;
using GamePlay.Modules;
using GamePlay.Commands;

namespace GamePlay.Hubs
{
    /// <summary>
    /// 플레이어 캐릭터(Hero)의 데이터 모델을 정의합니다.
    /// </summary>
    public class HeroModel : HubModelBase<HeroConfig>, IHeroModel
    {
        HeroData _data;

        // 장비, 피격, 피로, 스프린트 관련 하위 모델들.
        public EquipperModel EquipperModel { get; private set; }
        public DamageReceiverModel DamageReceiverModel { get; private set; }
        public FatigueModel FatigueModel { get; private set; }
        public SprintableMoverModel SprintableMoverModel { get; private set; }

        /// <summary>
        /// HeroModel의 생성자. Config와 Data를 바탕으로 하위 모델 초기화.
        /// </summary>
        public HeroModel(HeroConfig config, HeroData data) : base(config)
        {
            _data = data;

            // Config를 바탕으로 하위 모델 초기화
            EquipperModel = new EquipperModel(Config);
            DamageReceiverModel = new DamageReceiverModel(Config);
            FatigueModel = new FatigueModel(Config, _data.FatigueData);
            SprintableMoverModel = new SprintableMoverModel(Config, Config);
        }

        /// <summary>
        /// 유효성 검사 이벤트가 호출되었을 때 실행되는 로직.
        /// </summary>
        protected override void OnValidated()
        {
            EquipperModel.ResetEquipSlots();
        }

        /// <summary>
        /// HeroModel에 명령을 실행합니다.
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