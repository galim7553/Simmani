using System.Collections;
using System.Collections.Generic;
using GamePlay.Configs;
using UnityEngine;

namespace GamePlay.Datas
{
    public interface IDifficultyConfig
    {
        public enum DifficultyType
        {
            Easy,
            Normal,
            Difficult
        }
        DifficultyType Type { get; }
        float SansamRate { get; }
        int MaxOniCount { get; }
    }
}