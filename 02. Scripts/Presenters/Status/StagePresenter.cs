using GamePlay.Datas;
using GamePlay.Views;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Presenters
{
    public class StagePresenter : PresenterBase<IStageModel, StageView>
    {
        public StagePresenter(IStageModel model, StageView view) : base(model, view)
        {
            Initialize();
        }

        void Initialize()
        {
            _model.OnLevelChanged += UpdateSansamCount;
            UpdateSansamCount();
        }

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


