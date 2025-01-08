using GamePlay.Configs;
using GamePlay.Datas;

namespace GamePlay.Hubs.Equipments
{
    /// <summary>
    /// 장비 모델의 기본 구현 클래스.
    /// </summary>
    /// <typeparam name="T">장비 설정값 타입</typeparam>
    public abstract class EquipmentModel<T> : HubModelBase<T>, IEquipmentModel where T : EquipmentConfig
    {
        EquipmentConfig IEquipmentModel.Config => Config;
        ItemData _data;

        /// <summary>
        /// 장비가 현재 장착되어 있는지 여부.
        /// </summary>
        public bool HasEquipped => _data.HasEquipped;
        public EquipmentModel(T config, ItemData itemData) : base(config)
        {
            _data = itemData;
        }

        /// <summary>
        /// 장착 상태를 설정합니다.
        /// </summary>
        public void SetHasEquipped(bool hasEquipped)
        {
            _data.SetHasEquipped(hasEquipped);
        }
    }
}


