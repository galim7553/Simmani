using GamePlay.Datas;

namespace GamePlay.Modules
{
    /// <summary>
    /// �κ��丮 ��Ʈ�ѷ� �������̽�.
    /// </summary>
    public interface IInventoryController
    {
        /// <summary>���� �κ��丮�� Ȱ��ȭ�Ǿ� �ִ��� ����.</summary>
        bool IsActive { get; }

        /// <summary>
        /// �κ��丮�� ǥ�� ���¸� ����մϴ�.
        /// </summary>
        void ToggleInventory();

        /// <summary>
        /// �κ��丮�� Ư�� ���·� ǥ���ϰų� ����ϴ�.
        /// </summary>
        /// <param name="isVisible">�κ��丮�� ǥ������ ����.</param>
        /// <param name="shopModel">������ ���� ��.</param>
        void DisplayInventory(bool isVisible, IShopModel shopModel);
    }
}


