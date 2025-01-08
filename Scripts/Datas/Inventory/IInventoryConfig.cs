namespace GamePlay.Datas
{
    /// <summary>
    /// �κ��丮 ���� ������ �����ϴ� �������̽��Դϴ�.
    /// </summary>
    public interface IInventoryConfig
    {
        /// <summary>
        /// �κ��丮 ������ �ִ� ���� �Ѱ��Դϴ�.
        /// </summary>
        int SlotLimit { get; }

        /// <summary>
        /// �κ��丮 �� �������� ����Դϴ�.
        /// </summary>
        string ItemOnInventoryViewPrefabPath { get; }

        /// <summary>
        /// ��� ��ư�� �ؽ�Ʈ Ű�Դϴ�.
        /// </summary>
        string UseButtonTextKey { get; }

        /// <summary>
        /// ��� ���� ��ư�� �ؽ�Ʈ Ű�Դϴ�.
        /// </summary>
        string UnuseButtonTextKey { get; }

        /// <summary>
        /// ������ ��ư�� �ؽ�Ʈ Ű�Դϴ�.
        /// </summary>
        string DumpButtonTextKey { get; }

        /// <summary>
        /// �Ǹ� ���̵� �ؽ�Ʈ Ű�Դϴ�.
        /// </summary>
        string SellGuideTextKey { get; }

        /// <summary>
        /// ���� ���̵� �ؽ�Ʈ Ű�Դϴ�.
        /// </summary>
        string BuyGuideTextKey { get; }

        /// <summary>
        /// ��� ���� �޽��� �ؽ�Ʈ Ű�Դϴ�.
        /// </summary>
        string NotEnoughGoldTextKey { get; }

        /// <summary>
        /// ���� ���� �޽��� �ؽ�Ʈ Ű�Դϴ�.
        /// </summary>
        string NotEnoughtSlotTextKey { get; }
    }
}


