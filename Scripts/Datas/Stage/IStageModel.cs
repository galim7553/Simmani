using System;

namespace GamePlay.Datas
{
    /// <summary>
    /// �������� ���� ������ �����ϴ� �������̽��Դϴ�.
    /// </summary>
    public interface IStageModel
    {
        IStageConfig Config { get; }

        /// <summary>���� �������� ����.</summary>
        int Level { get; }

        /// <summary>���� ���������� ��ǥ ��� ����.</summary>
        int SansamCount { get; }

        /// <summary>���� ���� �̺�Ʈ.</summary>
        event Action OnLevelChanged;

        /// <summary>�������� ������ ������ŵ�ϴ�.</summary>
        void AddLevel();

        /// <summary>����� ��� ������ �߰��մϴ�.</summary>
        void AddSubmitedSansamCount(int count);

        /// <summary>���� �� Ű�� ��ȯ�մϴ�.</summary>
        string GetEnemyKey();

        /// <summary>�� ���� ������ ��ȯ�մϴ�.</summary>
        float GetEnemySpawnSpan();
    }
}

