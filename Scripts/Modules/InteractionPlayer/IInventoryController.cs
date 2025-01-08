using GamePlay.Datas;

namespace GamePlay.Modules
{
    /// <summary>
    /// 인벤토리 컨트롤러 인터페이스.
    /// </summary>
    public interface IInventoryController
    {
        /// <summary>현재 인벤토리가 활성화되어 있는지 여부.</summary>
        bool IsActive { get; }

        /// <summary>
        /// 인벤토리의 표시 상태를 토글합니다.
        /// </summary>
        void ToggleInventory();

        /// <summary>
        /// 인벤토리를 특정 상태로 표시하거나 숨깁니다.
        /// </summary>
        /// <param name="isVisible">인벤토리를 표시할지 여부.</param>
        /// <param name="shopModel">연관된 상점 모델.</param>
        void DisplayInventory(bool isVisible, IShopModel shopModel);
    }
}


