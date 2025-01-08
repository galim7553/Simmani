namespace GamePlay.Commands
{
    /// <summary>
    /// Hero ���� ���� ������ ����� ó���ϴ� �������̽�.
    /// </summary>
    public interface IHeroModel
    {
        /// <summary>
        /// �־��� ��� Ÿ�԰� ������ Hero �𵨿��� ����� ����.
        /// </summary>
        /// <param name="commandType">����� Ÿ��.</param>
        /// <param name="amount">��� ��.</param>
        void ExecuteCommand(IHeroModelCommandConfig.CommandType commandType, float amount);
    }
}


