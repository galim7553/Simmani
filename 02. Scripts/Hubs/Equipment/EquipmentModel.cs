using GamePlay.Configs;
using GamePlay.Datas;

namespace GamePlay.Hubs.Equipments
{
    /// <summary>
    /// ��� ���� �⺻ ���� Ŭ����.
    /// </summary>
    /// <typeparam name="T">��� ������ Ÿ��</typeparam>
    public abstract class EquipmentModel<T> : HubModelBase<T>, IEquipmentModel where T : EquipmentConfig
    {
        EquipmentConfig IEquipmentModel.Config => Config;
        ItemData _data;

        /// <summary>
        /// ��� ���� �����Ǿ� �ִ��� ����.
        /// </summary>
        public bool HasEquipped => _data.HasEquipped;
        public EquipmentModel(T config, ItemData itemData) : base(config)
        {
            _data = itemData;
        }

        /// <summary>
        /// ���� ���¸� �����մϴ�.
        /// </summary>
        public void SetHasEquipped(bool hasEquipped)
        {
            _data.SetHasEquipped(hasEquipped);
        }
    }
}


