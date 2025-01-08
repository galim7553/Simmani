using GamePlay.Datas;
using GamePlay.Views;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Presenters
{
    /// <summary>
    /// �κ��丮 �𵨰� ��Ű UI �׷��� �����ϴ� ��������.
    /// </summary>
    public class HotKeyGroupPresenter : ResourceDependentPresenterBase<IInventoryModel, HotKeyGroupView>
    {
        IHotKeyGroupConfig _config;

        Dictionary<string, (HotKeyInfo info, HotKeyView view)> _hotKeyMap = new Dictionary<string, (HotKeyInfo info, HotKeyView view)>();

        /// <summary>
        /// HotKeyGroupPresenter ������.
        /// </summary>
        /// <param name="model">�κ��丮 ��.</param>
        /// <param name="view">��Ű �׷� ��.</param>
        /// <param name="config">��Ű �׷� ����.</param>
        public HotKeyGroupPresenter(IInventoryModel model, HotKeyGroupView view, IHotKeyGroupConfig config) : base(model, view)
        {
            _config = config;
            Initialize();
        }


        /// <summary>
        /// �ʱ�ȭ �� ��-�� ������ ���ε�.
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
        /// Ư�� ��Ű ������ �ʱ�ȭ.
        /// </summary>
        void InitializeHotKey(HotKeyInfo info, HotKeyView view)
        {
            view.SetImage((int)HotKeyView.ImageKey.ItemImage, GetResource<Sprite>(info.SpritePath));
            UpdateHotKey(info, view);
            _hotKeyMap[info.TargetItemKey] = (info, view);
        }

        /// <summary>
        /// ������ �߰� �Ǵ� ���� �� ��Ű ������Ʈ.
        /// </summary>
        void UpdateHotKey(IItemModel itemModel)
        {
            if(_hotKeyMap.TryGetValue(itemModel.Config.Key, out var infoViewPair))
                UpdateHotKey(infoViewPair.info, infoViewPair.view);
        }

        /// <summary>
        /// Ư�� ��Ű�� ������ ������ ������Ʈ.
        /// </summary>
        void UpdateHotKey(HotKeyInfo info, HotKeyView view)
        {
            view.SetTMP((int)HotKeyView.TMPKey.CountText, _model.GetItemModelCount(info.TargetItemKey).ToString());
        }

        /// <summary>
        /// Ư�� ��Ű�� ����.
        /// </summary>
        /// <param name="index">��Ű �ε���.</param>
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

