using System.Collections;
using System.Collections.Generic;
using GamePlay.Datas;
using GamePlay.Modules;
using GamePlay.Views;
using UnityEngine;

namespace GamePlay.Presenters
{
    public class TownLoadingPresenter : ResourceDependentPresenterBase<IStageModel, TownLoadingView>
    {
        ITimeCycleModel _timeCycleModel;
        public TownLoadingPresenter(IStageModel model, ITimeCycleModel timeCycleModel, TownLoadingView view) : base(model, view)
        {
            _timeCycleModel = timeCycleModel;
        }

        public void Display(bool isVisible)
        {
            _view.gameObject.SetActive(isVisible);
            if(isVisible)
                UpdateView();
        }
        void UpdateView()
        {
            _view.SetTMP((int)TownLoadingView.TMPKey.DayText, $"{_timeCycleModel.GameDay + 1} ÀÏÂ÷ {GetString(_timeCycleModel.GameDayTextKey)}");
            _view.SetTMP((int)TownLoadingView.TMPKey.RequiredSansamCountText, $"{_model.SansamCount} °³");
            _view.SetImage((int)TownLoadingView.ImageKey.KoreanHourImage,
                GetResource<Sprite>(_timeCycleModel.KoreanHourSpritePath));
            _view.SetTMP((int)TownLoadingView.TMPKey.KoreanHourText,
                GetString(_timeCycleModel.KoreanHourTextKey));
        }
    }
}