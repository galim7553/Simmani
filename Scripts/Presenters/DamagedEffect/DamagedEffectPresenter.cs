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
    /// �÷��̾ ���ظ� �Ծ��� �� �ð��� ȿ���� ó���ϴ� ��������.
    /// </summary>
    public class DamagedEffectPresenter : PresenterBase<IDamagedEffectConfig, DamagedEffectView>
    {
        public DamagedEffectPresenter(IDamagedEffectConfig config, DamagedEffectView view) : base(config, view)
        {
        }

        /// <summary>
        /// �÷��̾ ���ظ� �Ծ��� �� ȿ���� ����մϴ�.
        /// </summary>
        public void OnHeroDamaged()
        {
            _view.PlayEffect(_model.WarningDuration, _model.WarningFadeOutDuration,
                _model.BloodDuration, _model.BloodFadeOutDuration);
        }
    }
}


