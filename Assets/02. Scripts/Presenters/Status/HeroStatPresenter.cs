using GamePlay.Hubs;
using GamePlay.Modules;
using GamePlay.Views;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Presenters
{
    public class HeroStatPresenter : PresenterBase<HeroModel, HeroStatView>
    {
        IDamageReceiverModel _damageReceiverModel;
        IFatigueModel _fatigueModel;
        ISprinterModel _sprinterModel;

        public HeroStatPresenter(HeroModel model, HeroStatView view) : base(model, view)
        {
            _damageReceiverModel = model.DamageReceiverModel;
            _fatigueModel = model.FatigueModel;
            _sprinterModel = model.SprintableMoverModel;

            Initialize();
        }

        void Initialize()
        {
            _damageReceiverModel.OnHealthChanged += UpdateHp;
            _sprinterModel.OnStaminaChanged += UpdateStamina;
            _fatigueModel.OnFatigueChanged += UpdateFatigue;

            UpdateHp();
            UpdateStamina();
            UpdateFatigue();
        }

        void UpdateHp()
        {
            _view.SetImageFillAmount((int)HeroStatView.ImageKey.HpBar, (_damageReceiverModel.Health / _damageReceiverModel.MaxHealth));
        }
        void UpdateStamina()
        {
            _view.SetImageFillAmount((int)HeroStatView.ImageKey.StaminaBar, (_sprinterModel.Stamina / _sprinterModel.MaxStamina));
        }
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

