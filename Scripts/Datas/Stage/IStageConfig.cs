using System;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Datas
{
    /// <summary>
    /// �������� ���� ������ �����ϴ� �������̽��Դϴ�.
    /// </summary>
    public interface IStageConfig
    {
        /// <summary>�ּ� �ʱ� ��� ����.</summary>
        int MinInitialSansamCount { get; }

        /// <summary>�ִ� �ʱ� ��� ����.</summary>
        int MaxInitialSansamCount { get; }

        /// <summary>���� ���� �� �ּ� �߰� ��� ����.</summary>
        int MinIncreaseSansamCount { get; }

        /// <summary>���� ���� �� �ִ� �߰� ��� ����.</summary>
        int MaxIncreaseSansamCount { get; }

        /// <summary>�ּ� �� ���� �ݰ�.</summary>
        float MinEnemySpawnRadius { get; }

        /// <summary>�ִ� �� ���� �ݰ�.</summary>
        float MaxEnemySpawnRadius { get; }

        /// <summary>���������� �� ���� ������ �����ϴ� ����Ʈ.</summary>
        IReadOnlyList<StageEnemyInfo> StageEnemyInfos { get; }
    }

    /// <summary>
    /// Ư�� ���������� �� ���� ������ �����ϴ� Ŭ�����Դϴ�.
    /// </summary>
    [Serializable]
    public class StageEnemyInfo
    {
        [SerializeField] int _minLevel = 0;
        [SerializeField] string[] _enemyKeys = new string[] { "Oni_0" };
        [SerializeField] float[] _enemyRates = new float[] { 1 };
        [SerializeField] float _minSpawnSpan = 5.0f;
        [SerializeField] float _maxSpawnSpan = 10.0f;

        /// <summary>�� ������ ������ �ּ� ����.</summary>
        public int MinLevel => _minLevel;

        /// <summary>���� Ű ����Ʈ.</summary>
        public IReadOnlyList<string> EnemyKeys => _enemyKeys;

        /// <summary>���� ���� Ȯ�� ����Ʈ.</summary>
        public IReadOnlyList<float> EnemyRates => _enemyRates;

        /// <summary>�� ���� �ּ� ����.</summary>
        public float MinSpawnSpan => _minSpawnSpan;

        /// <summary>�� ���� �ִ� ����.</summary>
        public float MaxSpawnSpan => _maxSpawnSpan;
    }
}