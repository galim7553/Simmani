using GamePlay.Modules.AI;

namespace GamePlay.Factories
{
    /// <summary>
    /// AI �ൿ(Behaviour)�� �����ϴ� ���丮 �������̽�.
    /// </summary>
    public interface IBehaviourFactory
    {
        /// <summary>
        /// �־��� Ű�� AI �ν��Ͻ��� ������� �ൿ(Behaviour)�� �����մϴ�.
        /// </summary>
        /// <param name="key">�ൿ�� Ű ��.</param>
        /// <param name="ai">�ൿ�� ������ AI �ν��Ͻ�.</param>
        /// <returns>������ �ൿ �ν��Ͻ�.</returns>
        IBehaviour CreateBehaviour(string key, IAI ai);
    }

}

