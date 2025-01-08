using System;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Datas
{
    /// <summary>
    /// 스테이지 설정 정보를 정의하는 인터페이스입니다.
    /// </summary>
    public interface IStageConfig
    {
        /// <summary>최소 초기 산삼 개수.</summary>
        int MinInitialSansamCount { get; }

        /// <summary>최대 초기 산삼 개수.</summary>
        int MaxInitialSansamCount { get; }

        /// <summary>레벨 증가 시 최소 추가 산삼 개수.</summary>
        int MinIncreaseSansamCount { get; }

        /// <summary>레벨 증가 시 최대 추가 산삼 개수.</summary>
        int MaxIncreaseSansamCount { get; }

        /// <summary>최소 적 스폰 반경.</summary>
        float MinEnemySpawnRadius { get; }

        /// <summary>최대 적 스폰 반경.</summary>
        float MaxEnemySpawnRadius { get; }

        /// <summary>스테이지별 적 생성 정보를 포함하는 리스트.</summary>
        IReadOnlyList<StageEnemyInfo> StageEnemyInfos { get; }
    }

    /// <summary>
    /// 특정 스테이지의 적 생성 정보를 정의하는 클래스입니다.
    /// </summary>
    [Serializable]
    public class StageEnemyInfo
    {
        [SerializeField] int _minLevel = 0;
        [SerializeField] string[] _enemyKeys = new string[] { "Oni_0" };
        [SerializeField] float[] _enemyRates = new float[] { 1 };
        [SerializeField] float _minSpawnSpan = 5.0f;
        [SerializeField] float _maxSpawnSpan = 10.0f;

        /// <summary>적 생성이 가능한 최소 레벨.</summary>
        public int MinLevel => _minLevel;

        /// <summary>적의 키 리스트.</summary>
        public IReadOnlyList<string> EnemyKeys => _enemyKeys;

        /// <summary>적의 생성 확률 리스트.</summary>
        public IReadOnlyList<float> EnemyRates => _enemyRates;

        /// <summary>적 생성 최소 간격.</summary>
        public float MinSpawnSpan => _minSpawnSpan;

        /// <summary>적 생성 최대 간격.</summary>
        public float MaxSpawnSpan => _maxSpawnSpan;
    }
}