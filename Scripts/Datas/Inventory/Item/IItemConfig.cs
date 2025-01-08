namespace GamePlay.Datas
{
    /// <summary>
    /// ������ ������ �����ϴ� �������̽��Դϴ�.
    /// </summary>
    public interface IItemConfig
    {
        /// <summary>
        /// �������� ���� Ű�Դϴ�.
        /// </summary>
        string Key { get; }

        /// <summary>
        /// �������� Ÿ���Դϴ�.
        /// </summary>
        ItemType ItemType { get; }

        /// <summary>
        /// ������ ��� ���� �����Դϴ�.
        /// </summary>
        bool IsUsable { get; }

        /// <summary>
        /// ������ �ε����Դϴ�(���Ŀ� ���).
        /// </summary>
        int Index { get; }

        /// <summary>
        /// ������ �̸��� ���� ���ö������̼� Ű�Դϴ�.
        /// </summary>
        string ItemNameKey { get; }

        /// <summary>
        /// ������ �̹����� ����Դϴ�.
        /// </summary>
        string SpritePath { get; }

        /// <summary>
        /// ������ ���� ���� ���ö������̼� Ű�Դϴ�.
        /// </summary>
        string DescriptionKey { get; }

        /// <summary>
        /// ������ �����Դϴ�.
        /// </summary>
        int Price { get; }

        /// <summary>
        /// ������ ��뿡 ���� ���� Ű�Դϴ�.
        /// </summary>
        string UsageKey { get; }
    }
}


