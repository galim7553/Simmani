using GamePlay.Modules;
using GamePlay.Views;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Presenters
{
    public class TimeCyclePresenter : ResourceDependentPresenterBase<ITimeCycleModel, TimeCycleView>
    {
        TimeView _curTimeView;
        TimeView _prevTimeView;
        TimeView _nextTimeView;
        public TimeCyclePresenter(ITimeCycleModel model, TimeCycleView view) : base(model, view)
        {
            Initialize();
        }

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

        void UpdateTimeText()
        {
            _view.SetTMP((int)TimeCycleView.TMPKey.TimeText,
                GetString(_model.KoreanHourTextKey));
        }
        void UpdateDayText()
        {
            _view.SetTMP((int)TimeCycleView.TMPKey.DayText,
                GetString(_model.GameDayTextKey));
        }

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

