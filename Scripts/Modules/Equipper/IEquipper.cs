using GamePlay.Hubs.Equipments;

namespace GamePlay.Modules
{
    /// <summary>
    /// ��� ���� ������ �����ϴ� �������̽�.
    /// </summary>
    public interface IEquipper : IModule
    {
        /// <summary>
        /// ������ ��� ĳ��.
        /// </summary>
        EquipmentCache Cache { get; }

        /// <summary>
        /// �ʱ�ȭ �۾�. ���� ��� ������ ������� ���� ���� ó��.
        /// </summary>
        void Initialize();

        /// <summary>
        /// ��� �����մϴ�.
        /// </summary>
        void Equip(EquipSlot slot, IEquipmentModel model);

        /// <summary>
        /// ��� �����մϴ�.
        /// </summary>
        void Unequip(EquipSlot slot, IEquipmentModel model);
    }
}
