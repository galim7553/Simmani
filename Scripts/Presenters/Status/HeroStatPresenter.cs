using GamePlay.Hubs;
using GamePlay.Modules;
using GamePlay.Views;

namespace GamePlay.Presenters
{
    /// <summary>
    /// �÷��̾� ĳ����(Hero)�� ü��, ���¹̳�, �Ƿ� ���¸� �����ϰ� UI �並 ������Ʈ�ϴ� ��������.
    /// </summary>
    public class HeroStatPresenter : PresenterBase<HeroModel, HeroStatView>
    {
        IDamageReceiverModel _damageReceiverModel;
        IFatigueModel _fatigueModel;
        ISprinterModel _sprinterModel;

        /// <summary>
        /// HeroStatPresenter ������.
        /// </summary>
        /// <param name="model">���� ��.</param>
        /// <param name="view">���� ���� ��.</param>
        public HeroStatPresenter(HeroModel model, HeroStatView view) : base(model, view)
        {
            _damageReceiverModel = model.DamageReceiverModel;
            _fatigueModel = model.FatigueModel;
            _sprinterModel = model.SprintableMoverModel;

            Initialize();
        }

        /// <summary>
        /// �ʱ�ȭ �� ��-�� �̺�Ʈ ���ε�.
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
        /// ü��(Hp) ������Ʈ.
        /// </summary>
        void UpdateHp()
        {
            _view.SetImageFillAmount((int)HeroStatView.ImageKey.HpBar, (_damageReceiverModel.Health / _damageReceiverModel.MaxHealth));
        }

        /// <summary>
        /// ���¹̳� ������Ʈ.
        /// </summary>
        void UpdateStamina()
        {
            _view.SetImageFillAmount((int)HeroStatView.ImageKey.StaminaBar, (_sprinterModel.Stamina / _sprinterModel.MaxStamina));
        }

        /// <summary>
        /// �Ƿε� ������Ʈ.
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

