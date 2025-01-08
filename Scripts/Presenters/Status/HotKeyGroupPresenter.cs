using GamePlay.Datas;
using GamePlay.Views;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Presenters
{
    /// <summary>
    /// 인벤토리 모델과 핫키 UI 그룹을 연결하는 프레젠터.
    /// </summary>
    public class HotKeyGroupPresenter : ResourceDependentPresenterBase<IInventoryModel, HotKeyGroupView>
    {
        IHotKeyGroupConfig _config;

        Dictionary<string, (HotKeyInfo info, HotKeyView view)> _hotKeyMap = new Dictionary<string, (HotKeyInfo info, HotKeyView view)>();

        /// <summary>
        /// HotKeyGroupPresenter 생성자.
        /// </summary>
        /// <param name="model">인벤토리 모델.</param>
        /// <param name="view">핫키 그룹 뷰.</param>
        /// <param name="config">핫키 그룹 설정.</param>
        public HotKeyGroupPresenter(IInventoryModel model, HotKeyGroupView view, IHotKeyGroupConfig config) : base(model, view)
        {
            _config = config;
            Initialize();
        }


        /// <summary>
        /// 초기화 및 모델-뷰 데이터 바인딩.
        /// </summary>
        void Initialize()
        {
            if (_config.HotKeyInfos == null || _view.HotKeyViews == null) return;

            for(int i = 0; i < Mathf.Min(_config.HotKeyInfos.Count, _view.HotKeyViews.Count); i++)
                InitializeHotKey(_config.HotKeyInfos[i], _view.HotKeyViews[i]);

            _model.OnItemAdded += UpdateHotKey;
            _model.OnItemRemoved += UpdateHotKey;
        }


        /// <summary>
        /// 특정 핫키 정보를 초기화.
        /// </summary>
        void InitializeHotKey(HotKeyInfo info, HotKeyView view)
        {
            view.SetImage((int)HotKeyView.ImageKey.ItemImage, GetResource<Sprite>(info.SpritePath));
            UpdateHotKey(info, view);
            _hotKeyMap[info.TargetItemKey] = (info, view);
        }

        /// <summary>
        /// 아이템 추가 또는 제거 시 핫키 업데이트.
        /// </summary>
        void UpdateHotKey(IItemModel itemModel)
        {
            if(_hotKeyMap.TryGetValue(itemModel.Config.Key, out var infoViewPair))
                UpdateHotKey(infoViewPair.info, infoViewPair.view);
        }

        /// <summary>
        /// 특정 핫키의 아이템 개수를 업데이트.
        /// </summary>
        void UpdateHotKey(HotKeyInfo info, HotKeyView view)
        {
            view.SetTMP((int)HotKeyView.TMPKey.CountText, _model.GetItemModelCount(info.TargetItemKey).ToString());
        }

        /// <summary>
        /// 특정 핫키를 실행.
        /// </summary>
        /// <param name="index">핫키 인덱스.</param>
        public void ExecuteHotKey(int index)
        {
            if (_config.HotKeyInfos == null) return;
            if (index < 0 || index >= _config.HotKeyInfos.Count) return;
            HotKeyInfo info = _config.HotKeyInfos[index];
            if (_model.TryGetItemModel(info.TargetItemKey, out var itemModel))
                _model.UseItem(itemModel);
        }

        public override void Clear()
        {
            base.Clear();

            _model.OnItemAdded -= UpdateHotKey;
            _model.OnItemRemoved -= UpdateHotKey;
        }
    }

}

