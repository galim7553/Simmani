using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Datas
{
    public interface IStageConfig
    {
        int MinInitialSansamCount { get; }
        int MaxInitialSansamCount { get; }
        int MinIncreaseSansamCount { get; }
        int MaxIncreaseSansamCount { get; }
        float MinEnemySpawnRadius { get; }
        float MaxEnemySpawnRadius { get; }
        IReadOnlyList<StageEnemyInfo> StageEnemyInfos { get; }
    }

    [Serializable]
    public class StageEnemyInfo
    {
        [SerializeField] int _minLevel = 0;
        [SerializeField] string[] _enemyKeys = new string[] { "Oni_0" };
        [SerializeField] float[] _enemyRates = new float[] { 1 };
        [SerializeField] float _minSpawnSpan = 5.0f;
        [SerializeField] float _maxSpawnSpan = 10.0f;

        public int MinLevel => _minLevel;
        public IReadOnlyList<string> EnemyKeys => _enemyKeys;
        public IReadOnlyList<float> EnemyRates => _enemyRates;
        public float MinSpawnSpan => _minSpawnSpan;
        public float MaxSpawnSpan => _maxSpawnSpan;
    }
}