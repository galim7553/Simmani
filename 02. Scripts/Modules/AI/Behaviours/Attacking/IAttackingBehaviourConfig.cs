namespace GamePlay.Modules.AI
{
    /// <summary>
    /// ���� �ൿ�� ���� �������� �����ϴ� �������̽��Դϴ�.
    /// </summary>
    public interface IAttackingBehaviourConfig : IBehaviourConfig
    {
        /// <summary>���� ����(��)�Դϴ�.</summary>
        float Span { get; }

        /// <summary>���� ���� ���� ����(��)�Դϴ�.</summary>
        float AngleThreshold { get; }

        /// <summary>���� �� ȸ�� �ӵ��Դϴ�.</summary>
        float RotSpeed { get; }
    }
}


