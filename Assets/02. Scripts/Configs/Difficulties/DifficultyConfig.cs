using System;
using System.Collections;
using System.Collections.Generic;
using GamePlay.Datas;
using UnityEngine;

namespace GamePlay.Configs
{
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


