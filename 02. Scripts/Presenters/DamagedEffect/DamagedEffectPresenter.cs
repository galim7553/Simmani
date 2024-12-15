using System.Collections;
using System.Collections.Generic;
using GamePlay.Views;
using UnityEngine;

namespace GamePlay.Presenters
{
    public interface IDamagedEffectConfig
    {
        float WarningDuration { get; }
        float WarningFadeOutDuration { get; }
        float BloodDuration { get; }
        float BloodFadeOutDuration { get; }
    }

    public class DamagedEffectPresenter : PresenterBase<IDamagedEffectConfig, DamagedEffectView>
    {
        public DamagedEffectPresenter(IDamagedEffectConfig config, DamagedEffectView view) : base(config, view)
        {
        }


        public void OnHeroDamaged()
        {
            _view.PlayEffect(_model.WarningDuration, _model.WarningFadeOutDuration,
                _model.BloodDuration, _model.BloodFadeOutDuration);
        }
    }
}


