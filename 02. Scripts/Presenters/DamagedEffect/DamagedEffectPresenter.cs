using GamePlay.Views;

namespace GamePlay.Presenters
{
    public interface IDamagedEffectConfig
    {
        float WarningDuration { get; }
        float WarningFadeOutDuration { get; }
        float BloodDuration { get; }
        float BloodFadeOutDuration { get; }
    }

    /// <summary>
    /// 플레이어가 피해를 입었을 때 시각적 효과를 처리하는 프레젠터.
    /// </summary>
    public class DamagedEffectPresenter : PresenterBase<IDamagedEffectConfig, DamagedEffectView>
    {
        public DamagedEffectPresenter(IDamagedEffectConfig config, DamagedEffectView view) : base(config, view)
        {
        }

        /// <summary>
        /// 플레이어가 피해를 입었을 때 효과를 재생합니다.
        /// </summary>
        public void OnHeroDamaged()
        {
            _view.PlayEffect(_model.WarningDuration, _model.WarningFadeOutDuration,
                _model.BloodDuration, _model.BloodFadeOutDuration);
        }
    }
}


