using GamePlay.Modules;
using System;

namespace GamePlay.Datas
{
    /// <summary>
    /// ������ �� Ŭ�����Դϴ�. �����Ϳ� ������ ������� ������ �����մϴ�.
    /// </summary>
    public class ItemModel : DataDependantModelBase<IItemConfig, ItemData>, IItemModel
    {
        public ItemData Data => _data;
        public IItemUsage Usage { get; private set; }

        public bool HasEquipped => _data.HasEquipped;
        public event Action OnHasEquippedChanged;

        /// <summary>
        /// ItemModel �������Դϴ�.
        /// </summary>
        /// <param name="config">������ ���� ��ü</param>
        /// <param name="data">������ ������ ��ü</param>
        /// <param name="usage">������ ��� ���� ��ü (������)</param>
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


