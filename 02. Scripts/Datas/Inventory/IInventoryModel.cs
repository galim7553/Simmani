using System;
using System.Collections.Generic;

namespace GamePlay.Datas
{
    /// <summary>
    /// 인벤토리 모델을 정의하는 인터페이스입니다.
    /// </summary>
    public interface IInventoryModel
    {
        IInventoryConfig Config { get; }
        IReadOnlyList<IItemModel> ItemModels { get; }
        int Gold { get; }
        bool IsFull { get; }

        /// <summary>
        /// 아이템 변경 시 발생하는 이벤트입니다.
        /// </summary>
        event Action OnChanged;

        /// <summary>
        /// 골드 변경 시 발생하는 이벤트입니다.
        /// </summary>
        event Action OnGoldChanged;

        /// <summary>
        /// 아이템이 추가될 때 발생하는 이벤트입니다.
        /// </summary>
        event Action<IItemModel> OnItemAdded;

        /// <summary>
        /// 아이템이 제거될 때 발생하는 이벤트입니다.
        /// </summary>
        event Action<IItemModel> OnItemRemoved;

        /// <summary>
        /// 지정된 키의 아이템을 인벤토리에 추가합니다.
        /// </summary>
        /// <param name="key">추가할 아이템 키</param>
        void AddItem(string key);

        /// <summary>
        /// 지정된 키의 아이템 모델을 검색합니다.
        /// </summary>
        /// <param name="key">검색할 아이템 키</param>
        /// <param name="itemModel">검색 결과를 반환할 아이템 모델</param>
        /// <returns>아이템 모델이 존재하면 true</returns>
        bool TryGetItemModel(string key, out IItemModel itemModel);

        /// <summary>
        /// 특정 키의 아이템 개수를 반환합니다.
        /// </summary>
        /// <param name="key">검색할 아이템 키</param>
        /// <returns>해당 키의 아이템 개수</returns>
        int GetItemModelCount(string key);

        /// <summary>
        /// 특정 유형의 아이템 개수를 반환합니다.
        /// </summary>
        /// <param name="itemType">검색할 아이템 유형</param>
        /// <returns>해당 유형의 아이템 개수</returns>
        int GetItemTypeCount(ItemType itemType);

        /// <summary>
        /// 지정된 수의 특정 유형 아이템을 제거합니다.
        /// </summary>
        /// <param name="itemType">제거할 아이템 유형</param>
        /// <param name="count">제거할 개수</param>
        void RemoveItemType(ItemType itemType, int count);

        /// <summary>
        /// 아이템을 사용합니다.
        /// </summary>
        /// <param name="itemModel">사용할 아이템 모델</param>
        void UseItem(IItemModel itemModel);

        /// <summary>
        /// 아이템을 버립니다.
        /// </summary>
        /// <param name="itemModel">버릴 아이템 모델</param>
        void DumpItem(IItemModel itemModel);

        /// <summary>
        /// 아이템을 판매합니다.
        /// </summary>
        /// <param name="itemModel">판매할 아이템 모델</param>
        void SellItem(IItemModel itemModel);

        /// <summary>
        /// 아이템을 구매합니다.
        /// </summary>
        /// <param name="itemModel">구매할 아이템 모델</param>
        void BuyItem(IItemModel itemModel);
    }
}


