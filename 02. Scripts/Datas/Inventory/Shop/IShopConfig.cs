namespace GamePlay.Datas
{
    /// <summary>
    /// 상점 설정 정보를 정의하는 인터페이스입니다.
    /// </summary>
    public interface IShopConfig
    {
        /// <summary>
        /// 상점 이름에 대한 로컬라이제이션 키입니다.
        /// </summary>
        string ShopNameKey { get; }

        /// <summary>
        /// 상점에서 판매할 아이템 키 배열입니다.
        /// </summary>
        string[] ItemKeys { get; }
    }
}


