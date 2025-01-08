using GamePlay.Hubs.Equipments;

namespace GamePlay.Modules
{
    /// <summary>
    /// 장비 장착 동작을 정의하는 인터페이스.
    /// </summary>
    public interface IEquipper : IModule
    {
        /// <summary>
        /// 장착된 장비 캐시.
        /// </summary>
        EquipmentCache Cache { get; }

        /// <summary>
        /// 초기화 작업. 모델의 장비 정보를 기반으로 실제 장착 처리.
        /// </summary>
        void Initialize();

        /// <summary>
        /// 장비를 장착합니다.
        /// </summary>
        void Equip(EquipSlot slot, IEquipmentModel model);

        /// <summary>
        /// 장비를 해제합니다.
        /// </summary>
        void Unequip(EquipSlot slot, IEquipmentModel model);
    }
}
