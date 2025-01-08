using System.Collections.Generic;

namespace GamePlay.Datas
{
    /// <summary>
    /// 상점 모델 인터페이스입니다.
    /// </summary>
    public interface IShopModel
    {
        /// <summary>
        /// 상점 설정 객체입니다.
        /// </summary>
        IShopConfig Config { get; }

        /// <summary>
        /// 상점에 포함된 아이템 모델의 읽기 전용 리스트입니다.
        /// </summary>
        IReadOnlyList<IItemModel> ItemModels { get; }
    }
}


