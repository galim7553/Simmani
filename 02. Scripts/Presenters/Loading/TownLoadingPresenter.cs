using GamePlay.Datas;
using GamePlay.Modules;
using GamePlay.Views;
using UnityEngine;

namespace GamePlay.Presenters
{
    /// <summary>
    /// ���� �ε� ȭ�� �����͸� �����ϰ� �並 ������Ʈ�ϴ� ��������.
    /// </summary>
    public class TownLoadingPresenter : ResourceDependentPresenterBase<IStageModel, TownLoadingView>
    {
        ITimeCycleModel _timeCycleModel;

        /// <summary>
        /// TownLoadingPresenter ������.
        /// </summary>
        /// <param name="model">�������� ��.</param>
        /// <param name="timeCycleModel">�ð� �ֱ� ��.</param>
        /// <param name="view">���� �ε� ��.</param>
        public TownLoadingPresenter(IStageModel model, ITimeCycleModel timeCycleModel, TownLoadingView view) : base(model, view)
        {
            _timeCycleModel = timeCycleModel;
        }

        /// <summary>
        /// �ε� ȭ���� ǥ���ϰų� ����.
        /// </summary>
        /// <param name="isVisible">ǥ�� ����.</param>
        public void Display(bool isVisible)
        {
            _view.gameObject.SetActive(isVisible);
            if(isVisible)
                UpdateView();
        }

        /// <summary>
        /// �並 ���� �� �����ͷ� ������Ʈ.
        /// </summary>
        void UpdateView()
        {
            _view.SetTMP((int)TownLoadingView.TMPKey.DayText, $"{_timeCycleModel.GameDay + 1} ���� {GetString(_timeCycleModel.GameDayTextKey)}");
            _view.SetTMP((int)TownLoadingView.TMPKey.RequiredSansamCountText, $"{_model.SansamCount} ��");
            _view.SetImage((int)TownLoadingView.ImageKey.KoreanHourImage,
                GetResource<Sprite>(_timeCycleModel.KoreanHourSpritePath));
            _view.SetTMP((int)TownLoadingView.TMPKey.KoreanHourText,
                GetString(_timeCycleModel.KoreanHourTextKey));
        }
    }
}