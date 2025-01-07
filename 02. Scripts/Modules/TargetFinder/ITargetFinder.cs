using System.Collections.Generic;

namespace GamePlay.Modules
{
    /// <summary>
    /// Ÿ�� Ž�� ��� �������̽�.
    /// </summary>
    public interface ITargetFinder : IModule
    {
        /// <summary>Ž�� ���� ������ ���� �켱������ ���� Ÿ���� ã��.</summary>
        IDamageReceiver FindTarget(float detectionLength);

        /// <summary>������ Ÿ���� ��Ʈ ���Ǿ� ���� �ִ��� Ȯ��.</summary>
        bool GetIsInHitSphere(IDamageReceiver target, float detectionLength);

        /// <summary>Ž�� ���� �� ��� Ÿ���� ã��.</summary>
        IReadOnlyList<IDamageReceiver> FindTargets(float detectionLength);
    }

}

