namespace GamePlay.Modules.AI
{
    /// <summary>
    /// �� AI�� �������� �����ϴ� �������̽��Դϴ�.
    /// </summary>
    public interface IEnemyAIConfig : IAIConfig
    {
        /// <summary>�⺻ �̵� �ӷ�.</summary>
        float BaseSpeed { get; }

        /// <summary>Idle ���¿��� ����� ���� Ű.</summary>
        string IdleBehaviourKey { get; }

        /// <summary>Trace ���¿��� ����� ���� Ű.</summary>
        string TraceBehaviourKey {get; }

        /// <summary>Attacking ���¿��� ����� ���� Ű.</summary>
        string AttackingBehaviourKey { get; }

        /// <summary>Ž�� ����.</summary>
        float DetectionLength { get; }

        /// <summary>���� ����.</summary>
        float TraceLength { get; }

        /// <summary>���� ����.</summary>
        float AttackLength { get; }

        /// <summary>Ÿ�� ���� ������.</summary>
        float HitSphereRadius { get; }
    }
}


