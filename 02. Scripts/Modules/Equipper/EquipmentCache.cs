using GamePlay.Hubs.Equipments;

namespace GamePlay.Modules
{

    /// <summary>
    /// ��� ĳ�ø� �����ϴ� Ŭ����.
    /// </summary>
    public class EquipmentCache
    {

        /// <summary>
        /// ������ ����.
        /// </summary>
        public IWeapon Weapon { get; private set; }


        /// <summary>
        /// ��� ĳ�ÿ� �߰��մϴ�.
        /// </summary>
        public void AddEquipment(IEquipment equipment)
        {
            switch (equipment)
            {
                case IWeapon weapon:
                    Weapon = weapon;
                    break;
            }
        }

        /// <summary>
        /// ��� ĳ�ÿ��� �����մϴ�.
        /// </summary>
        public void RemoveEquipment(IEquipment equipment)
        {
            switch (equipment)
            {
                case IWeapon:
                    Weapon = null;
                    break;
            }
        }
    }
}