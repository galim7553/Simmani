using System;
using GamePlay.Datas;
using UnityEngine;

namespace GamePlay.Configs
{
    /// <summary>
    /// 게임의 난이도 설정을 정의하는 클래스입니다.
    /// 난이도 유형, 산삼 확률, 최대 적 수와 같은 데이터를 제공합니다.
    /// </summary>
    [Serializable]
    public class DifficultyConfig : IDifficultyConfig
    {
        [ReadOnly]
        [SerializeField] IDifficultyConfig.DifficultyType _type;
        [SerializeField] float _sansamRate = 0.1f;
        [SerializeField] int _maxOniCount = 50;
        public IDifficultyConfig.DifficultyType Type => _type;
        public float SansamRate => _sansamRate;
        public int MaxOniCount => _maxOniCount;

        public DifficultyConfig(IDifficultyConfig.DifficultyType type)
        {
            _type = type;
        }
    }
}


