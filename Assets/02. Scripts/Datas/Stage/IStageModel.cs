using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Datas
{
    public interface IStageModel
    {
        IStageConfig Config { get; }

        int Level { get; }
        int SansamCount { get; }

        event Action OnLevelChanged;

        void AddLevel();
        void AddSubmitedSansamCount(int count);
        string GetEnemyKey();
        float GetEnemySpawnSpan();
    }
}

