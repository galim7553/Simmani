using GamePlay.Hubs;
using GamePlay.Modules;
using GamePlay.Views;

namespace GamePlay.Presenters
{
    /// <summary>
    /// 플레이어 캐릭터(Hero)의 체력, 스태미나, 피로 상태를 관리하고 UI 뷰를 업데이트하는 프레젠터.
    /// </summary>
    public class HeroStatPresenter : PresenterBase<HeroModel, HeroStatView>
    {
        IDamageReceiverModel _damageReceiverModel;
        IFatigueModel _fatigueModel;
        ISprinterModel _sprinterModel;

        /// <summary>
        /// HeroStatPresenter 생성자.
        /// </summary>
        /// <param name="model">영웅 모델.</param>
        /// <param name="view">영웅 스탯 뷰.</param>
        public HeroStatPresenter(HeroModel model, HeroStatView view) : base(model, view)
        {
            _damageReceiverModel = model.DamageReceiverModel;
            _fatigueModel = model.FatigueModel;
            _sprinterModel = model.SprintableMoverModel;

            Initialize();
        }

        /// <summary>
        /// 초기화 및 모델-뷰 이벤트 바인딩.
        /// </summary>
        void Initialize()
        {
            _damageReceiverModel.OnHealthChanged += UpdateHp;
            _sprinterModel.OnStaminaChanged += UpdateStamina;
            _fatigueModel.OnFatigueChanged += UpdateFatigue;

            UpdateHp();
            UpdateStamina();
            UpdateFatigue();
        }

        /// <summary>
        /// 체력(Hp) 업데이트.
        /// </summary>
        void UpdateHp()
        {
            _view.SetImageFillAmount((int)HeroStatView.ImageKey.HpBar, (_damageReceiverModel.Health / _damageReceiverModel.MaxHealth));
        }

        /// <summary>
        /// 스태미나 업데이트.
        /// </summary>
        void UpdateStamina()
        {
            _view.SetImageFillAmount((int)HeroStatView.ImageKey.StaminaBar, (_sprinterModel.Stamina / _sprinterModel.MaxStamina));
        }

        /// <summary>
        /// 피로도 업데이트.
        /// </summary>
        void UpdateFatigue()
        {
            _view.SetImageFillAmount((int)HeroStatView.ImageKey.FatigueBar, (_fatigueModel.Fatigue / _fatigueModel.MaxFatigue));
        }


        public override void Clear()
        {
            base.Clear();

            _damageReceiverModel.OnHealthChanged -= UpdateHp;
            _sprinterModel.OnStaminaChanged -= UpdateStamina;
            _fatigueModel.OnFatigueChanged -= UpdateFatigue;
        }
    }

}

