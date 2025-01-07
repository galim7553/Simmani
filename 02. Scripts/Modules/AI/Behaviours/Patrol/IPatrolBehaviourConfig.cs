namespace GamePlay.Modules.AI
{
    /// <summary>
    /// ���� �ൿ�� ���� �������� �����ϴ� �������̽��Դϴ�.
    /// </summary>
    public interface IPatrolBehaviourConfig : IBehaviourConfig
    {
        /// <summary>���� �ݰ� �ּҰ�.</summary>
        float MinRadius { get; }

        /// <summary>���� �ݰ� �ִ밪.</summary>
        float MaxRadius { get; }

        /// <summary>���� ��� �ð� �ּҰ�(��).</summary>
        float MinSpan { get; }

        /// <summary>���� ��� �ð� �ִ밪(��).</summary>
        float MaxSpan { get; }

        /// <summary>���� �� �ӵ� ����.</summary>
        float SpeedRatio { get; }
    }
}