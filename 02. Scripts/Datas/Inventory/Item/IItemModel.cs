using System;

namespace GamePlay.Datas
{
    public enum ItemType
    {
        Sansam,
        Sellable,
        Equipment,
        Consumable,
        Passive,
    }

    /// <summary>
    /// 아이템 모델 인터페이스입니다.
    /// </summary>
    public interface IItemModel
    {
        ItemData Data { get; }

        /// <summary>
        /// 아이템의 장착 여부입니다.
        /// </summary>
        bool HasEquipped { get; }
        IItemConfig Config { get; }

        /// <summary>
        /// 아이템 사용 관련 동작 객체입니다.
        /// </summary>
        IItemUsage Usage { get; }

        /// <summary>
        /// 아이템 장착 상태 변경 이벤트입니다.
        /// </summary>
        event Action OnHasEquippedChanged;
    }

}

