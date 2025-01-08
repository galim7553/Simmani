using GamePlay.Modules;
using System;

namespace GamePlay.Datas
{
    /// <summary>
    /// 아이템 모델 클래스입니다. 데이터와 설정을 기반으로 동작을 정의합니다.
    /// </summary>
    public class ItemModel : DataDependantModelBase<IItemConfig, ItemData>, IItemModel
    {
        public ItemData Data => _data;
        public IItemUsage Usage { get; private set; }

        public bool HasEquipped => _data.HasEquipped;
        public event Action OnHasEquippedChanged;

        /// <summary>
        /// ItemModel 생성자입니다.
        /// </summary>
        /// <param name="config">아이템 설정 객체</param>
        /// <param name="data">아이템 데이터 객체</param>
        /// <param name="usage">아이템 사용 동작 객체 (선택적)</param>
        public ItemModel(IItemConfig config, ItemData data, IItemUsage usage = null) : base(config, data)
        {
            Usage = usage;

            _data.OnHasEquippedChanged += OnDataHasEquippedChanged;
        }

        void OnDataHasEquippedChanged()
        {
            OnHasEquippedChanged?.Invoke();
        }
    }
}


