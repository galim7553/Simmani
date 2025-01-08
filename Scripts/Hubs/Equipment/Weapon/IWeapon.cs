namespace GamePlay.Hubs.Equipments
{
    /// <summary>
    /// 무기 인터페이스. 무기의 기본 동작 정의.
    /// </summary>
    public interface IWeapon : IEquipment
    {
        /// <summary>
        /// 무기의 충돌체 활성화/비활성화 설정.
        /// </summary>
        /// <param name="isActive">활성화 여부</param>
        void SetColliderActive(bool isActive);
    }
}