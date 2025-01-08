using GamePlay.Datas;
using GamePlay.Modules;
using GamePlay.Views;
using UnityEngine;

namespace GamePlay.Presenters
{
    /// <summary>
    /// 마을 로딩 화면 데이터를 관리하고 뷰를 업데이트하는 프레젠터.
    /// </summary>
    public class TownLoadingPresenter : ResourceDependentPresenterBase<IStageModel, TownLoadingView>
    {
        ITimeCycleModel _timeCycleModel;

        /// <summary>
        /// TownLoadingPresenter 생성자.
        /// </summary>
        /// <param name="model">스테이지 모델.</param>
        /// <param name="timeCycleModel">시간 주기 모델.</param>
        /// <param name="view">마을 로딩 뷰.</param>
        public TownLoadingPresenter(IStageModel model, ITimeCycleModel timeCycleModel, TownLoadingView view) : base(model, view)
        {
            _timeCycleModel = timeCycleModel;
        }

        /// <summary>
        /// 로딩 화면을 표시하거나 숨김.
        /// </summary>
        /// <param name="isVisible">표시 여부.</param>
        public void Display(bool isVisible)
        {
            _view.gameObject.SetActive(isVisible);
            if(isVisible)
                UpdateView();
        }

        /// <summary>
        /// 뷰를 현재 모델 데이터로 업데이트.
        /// </summary>
        void UpdateView()
        {
            _view.SetTMP((int)TownLoadingView.TMPKey.DayText, $"{_timeCycleModel.GameDay + 1} 일차 {GetString(_timeCycleModel.GameDayTextKey)}");
            _view.SetTMP((int)TownLoadingView.TMPKey.RequiredSansamCountText, $"{_model.SansamCount} 개");
            _view.SetImage((int)TownLoadingView.ImageKey.KoreanHourImage,
                GetResource<Sprite>(_timeCycleModel.KoreanHourSpritePath));
            _view.SetTMP((int)TownLoadingView.TMPKey.KoreanHourText,
                GetString(_timeCycleModel.KoreanHourTextKey));
        }
    }
}