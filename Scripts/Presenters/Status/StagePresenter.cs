using GamePlay.Datas;
using GamePlay.Views;

namespace GamePlay.Presenters
{
    /// <summary>
    /// 스테이지 데이터를 뷰와 연결하는 프리젠터 클래스.
    /// </summary>
    public class StagePresenter : PresenterBase<IStageModel, StageView>
    {

        /// <summary>
        /// StagePresenter 생성자.
        /// </summary>
        /// <param name="model">스테이지 데이터 모델.</param>
        /// <param name="view">스테이지 뷰.</param>
        public StagePresenter(IStageModel model, StageView view) : base(model, view)
        {
            Initialize();
        }

        /// <summary>
        /// 초기화 작업: 이벤트 등록 및 초기 UI 업데이트.
        /// </summary>
        void Initialize()
        {
            _model.OnLevelChanged += UpdateSansamCount;
            UpdateSansamCount();
        }

        /// <summary>
        /// 산삼 개수를 업데이트.
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


