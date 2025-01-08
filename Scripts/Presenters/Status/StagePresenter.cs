using GamePlay.Datas;
using GamePlay.Views;

namespace GamePlay.Presenters
{
    /// <summary>
    /// �������� �����͸� ��� �����ϴ� �������� Ŭ����.
    /// </summary>
    public class StagePresenter : PresenterBase<IStageModel, StageView>
    {

        /// <summary>
        /// StagePresenter ������.
        /// </summary>
        /// <param name="model">�������� ������ ��.</param>
        /// <param name="view">�������� ��.</param>
        public StagePresenter(IStageModel model, StageView view) : base(model, view)
        {
            Initialize();
        }

        /// <summary>
        /// �ʱ�ȭ �۾�: �̺�Ʈ ��� �� �ʱ� UI ������Ʈ.
        /// </summary>
        void Initialize()
        {
            _model.OnLevelChanged += UpdateSansamCount;
            UpdateSansamCount();
        }

        /// <summary>
        /// ��� ������ ������Ʈ.
        /// </summary>
        void UpdateSansamCount()
        {
            _view.SetTMP((int)StageView.TMPKey.SansamCountText, _model.SansamCount.ToString());
        }

        public override void Clear()
        {
            base.Clear();

            _model.OnLevelChanged -= UpdateSansamCount;
        }
    }
}


