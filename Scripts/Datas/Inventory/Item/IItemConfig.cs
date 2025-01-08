namespace GamePlay.Datas
{
    /// <summary>
    /// 아이템 설정을 정의하는 인터페이스입니다.
    /// </summary>
    public interface IItemConfig
    {
        /// <summary>
        /// 아이템의 고유 키입니다.
        /// </summary>
        string Key { get; }

        /// <summary>
        /// 아이템의 타입입니다.
        /// </summary>
        ItemType ItemType { get; }

        /// <summary>
        /// 아이템 사용 가능 여부입니다.
        /// </summary>
        bool IsUsable { get; }

        /// <summary>
        /// 아이템 인덱스입니다(정렬에 사용).
        /// </summary>
        int Index { get; }

        /// <summary>
        /// 아이템 이름에 대한 로컬라이제이션 키입니다.
        /// </summary>
        string ItemNameKey { get; }

        /// <summary>
        /// 아이템 이미지의 경로입니다.
        /// </summary>
        string SpritePath { get; }

        /// <summary>
        /// 아이템 설명에 대한 로컬라이제이션 키입니다.
        /// </summary>
        string DescriptionKey { get; }

        /// <summary>
        /// 아이템 가격입니다.
        /// </summary>
        int Price { get; }

        /// <summary>
        /// 아이템 사용에 대한 설정 키입니다.
        /// </summary>
        string UsageKey { get; }
    }
}


