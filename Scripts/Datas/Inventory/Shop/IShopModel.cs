using System.Collections.Generic;

namespace GamePlay.Datas
{
    /// <summary>
    /// ���� �� �������̽��Դϴ�.
    /// </summary>
    public interface IShopModel
    {
        /// <summary>
        /// ���� ���� ��ü�Դϴ�.
        /// </summary>
        IShopConfig Config { get; }

        /// <summary>
        /// ������ ���Ե� ������ ���� �б� ���� ����Ʈ�Դϴ�.
        /// </summary>
        IReadOnlyList<IItemModel> ItemModels { get; }
    }
}


