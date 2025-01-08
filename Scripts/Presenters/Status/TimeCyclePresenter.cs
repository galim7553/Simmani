using GamePlay.Modules;
using GamePlay.Views;
using UnityEngine;

namespace GamePlay.Presenters
{
    /// <summary>
    /// 시간 흐름(Time Cycle)을 뷰와 동기화하는 Presenter 클래스.
    /// </summary>
    public class TimeCyclePresenter : ResourceDependentPresenterBase<ITimeCycleModel, TimeCycleView>
    {
        TimeView _curTimeView;
        TimeView _prevTimeView;
        TimeView _nextTimeView;

        /// <summary>
        /// TimeCyclePresenter 생성자.
        /// </summary>
        /// <param name="model">TimeCycle 모델.</param>
        /// <param name="view">TimeCycle 뷰.</param>
        public TimeCyclePresenter(ITimeCycleModel model, TimeCycleView view) : base(model, view)
        {
            Initialize();
        }

        /// <summary>
        /// 초기화: 이벤트 등록 및 UI 동기화.
        /// </summary>
        void Initialize()
        {
            _model.OnHourChanged += UpdateTimeText;
            _model.OnHourChanged += UpdateDayText;
            _model.OnHourChanged += UpdateTimeViews;

            _curTimeView = _view.GetTimeView((int)TimeCycleView.TimeViewKey.CurTimeView);
            _prevTimeView = _view.GetTimeView((int)TimeCycleView.TimeViewKey.PrevTimeView);
            _nextTimeView = _view.GetTimeView((int)TimeCycleView.TimeViewKey.NextTimeView);

            UpdateTimeText();
            UpdateDayText();
            UpdateTimeViews();
        }

        /// <summary>
        /// 시간 텍스트 업데이트.
        /// </summary>
        void UpdateTimeText()
        {
            _view.SetTMP((int)TimeCycleView.TMPKey.TimeText,
                GetString(_model.KoreanHourTextKey));
        }

        /// <summary>
        /// 날짜 텍스트 업데이트.
        /// </summary>
        void UpdateDayText()
        {
            _view.SetTMP((int)TimeCycleView.TMPKey.DayText,
                GetString(_model.GameDayTextKey));
        }

        /// <summary>
        /// 시간 뷰(현재, 이전, 다음) 업데이트.
        /// </summary>
        void UpdateTimeViews()
        {
            _curTimeView.SetImage((int)TimeView.ImageKey.TimeImage,
                GetResource<Sprite>(_model.KoreanHourSpritePath));

            int prevKoreanHour = (_model.KoreanHour + 11) % 12;

            _prevTimeView.SetImage((int)TimeView.ImageKey.TimeImage,
                GetResource<Sprite>(string.Format(_model.Config.KoreanHourSpritePathFormat, prevKoreanHour)));

            int nextKoreanHour = (_model.KoreanHour + 1) % 12;

            _nextTimeView.SetImage((int)TimeView.ImageKey.TimeImage,
                GetResource<Sprite>(string.Format(_model.Config.KoreanHourSpritePathFormat, nextKoreanHour)));
        }


        public override void Clear()
        {
            base.Clear();

            _model.OnHourChanged -= UpdateTimeText;
            _model.OnHourChanged -= UpdateDayText;
            _model.OnHourChanged -= UpdateTimeViews;
        }
    }

}

