using GamePlay.Hubs.Equipments;

namespace GamePlay.Modules
{

    /// <summary>
    /// 장비 캐시를 관리하는 클래스.
    /// </summary>
    public class EquipmentCache
    {

        /// <summary>
        /// 장착된 무기.
        /// </summary>
        public IWeapon Weapon { get; private set; }


        /// <summary>
        /// 장비를 캐시에 추가합니다.
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
        /// 장비를 캐시에서 제거합니다.
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