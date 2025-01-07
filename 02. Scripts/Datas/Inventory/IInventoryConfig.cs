namespace GamePlay.Datas
{
    /// <summary>
    /// 인벤토리 설정 정보를 정의하는 인터페이스입니다.
    /// </summary>
    public interface IInventoryConfig
    {
        /// <summary>
        /// 인벤토리 슬롯의 최대 수용 한계입니다.
        /// </summary>
        int SlotLimit { get; }

        /// <summary>
        /// 인벤토리 뷰 프리팹의 경로입니다.
        /// </summary>
        string ItemOnInventoryViewPrefabPath { get; }

        /// <summary>
        /// 사용 버튼의 텍스트 키입니다.
        /// </summary>
        string UseButtonTextKey { get; }

        /// <summary>
        /// 사용 해제 버튼의 텍스트 키입니다.
        /// </summary>
        string UnuseButtonTextKey { get; }

        /// <summary>
        /// 버리기 버튼의 텍스트 키입니다.
        /// </summary>
        string DumpButtonTextKey { get; }

        /// <summary>
        /// 판매 가이드 텍스트 키입니다.
        /// </summary>
        string SellGuideTextKey { get; }

        /// <summary>
        /// 구매 가이드 텍스트 키입니다.
        /// </summary>
        string BuyGuideTextKey { get; }

        /// <summary>
        /// 골드 부족 메시지 텍스트 키입니다.
        /// </summary>
        string NotEnoughGoldTextKey { get; }

        /// <summary>
        /// 슬롯 부족 메시지 텍스트 키입니다.
        /// </summary>
        string NotEnoughtSlotTextKey { get; }
    }
}


