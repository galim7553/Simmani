namespace GamePlay.Hubs.Equipments
{
    /// <summary>
    /// ���� �������̽�. ������ �⺻ ���� ����.
    /// </summary>
    public interface IWeapon : IEquipment
    {
        /// <summary>
        /// ������ �浹ü Ȱ��ȭ/��Ȱ��ȭ ����.
        /// </summary>
        /// <param name="isActive">Ȱ��ȭ ����</param>
        void SetColliderActive(bool isActive);
    }
}