using GamePlay.Modules;
using GamePlay.Views;
using UnityEngine;

namespace GamePlay.Presenters
{
    /// <summary>
    /// �ð� �帧(Time Cycle)�� ��� ����ȭ�ϴ� Presenter Ŭ����.
    /// </summary>
    public class TimeCyclePresenter : ResourceDependentPresenterBase<ITimeCycleModel, TimeCycleView>
    {
        TimeView _curTimeView;
        TimeView _prevTimeView;
        TimeView _nextTimeView;

        /// <summary>
        /// TimeCyclePresenter ������.
        /// </summary>
        /// <param name="model">TimeCycle ��.</param>
        /// <param name="view">TimeCycle ��.</param>
        public TimeCyclePresenter(ITimeCycleModel model, TimeCycleView view) : base(model, view)
        {
            Initialize();
        }

        /// <summary>
        /// �ʱ�ȭ: �̺�Ʈ ��� �� UI ����ȭ.
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
        /// �ð� �ؽ�Ʈ ������Ʈ.
        /// </summary>
        void UpdateTimeText()
        {
            _view.SetTMP((int)TimeCycleView.TMPKey.TimeText,
                GetString(_model.KoreanHourTextKey));
        }

        /// <summary>
        /// ��¥ �ؽ�Ʈ ������Ʈ.
        /// </summary>
        void UpdateDayText()
        {
            _view.SetTMP((int)TimeCycleView.TMPKey.DayText,
                GetString(_model.GameDayTextKey));
        }

        /// <summary>
        /// �ð� ��(����, ����, ����) ������Ʈ.
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

