namespace GamePlay.Datas
{
    /// <summary>
    /// ���� ���� ������ �����ϴ� �������̽��Դϴ�.
    /// </summary>
    public interface IShopConfig
    {
        /// <summary>
        /// ���� �̸��� ���� ���ö������̼� Ű�Դϴ�.
        /// </summary>
        string ShopNameKey { get; }

        /// <summary>
        /// �������� �Ǹ��� ������ Ű �迭�Դϴ�.
        /// </summary>
        string[] ItemKeys { get; }
    }
}


