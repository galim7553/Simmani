using System;
using System.Collections;
using System.Collections.Generic;
using GamePlay.Modules;
using UnityEngine;

namespace GamePlay.Datas
{
    public class StageModel : DataDependantModelBase<IStageConfig, StageData>, IStageModel
    {
        StageEnemyInfo _curStageEnemyInfo;

        public int Level => _data.SansamCounts.Count;
        public int SansamCount => _data.SansamCounts[_data.SansamCounts.Count - 1];
        public int SubmitedSansamCount => _data.SubmitedSansamCount;
        public int RemainedSansamCount => SansamCount - SubmitedSansamCount;

        public event Action OnLevelChanged;
        
        public StageModel(IStageConfig config, StageData data) : base(config, data)
        {
            AddLevel();
        }

        public void AddLevel()
        {
            if (_data.SansamCounts.Count == 0)
                _data.AddSansamCount(UnityEngine.Random.Range(Config.MinInitialSansamCount, Config.MaxInitialSansamCount));
            else
                _data.AddSansamCount(SansamCount + UnityEngine.Random.Range(Config.MinIncreaseSansamCount, Config.MaxIncreaseSansamCount));

            _data.SetSubmitedSansamCount(0);
            CalculateCurStageEnemyInfo();
            OnLevelChanged?.Invoke();
        }

        void CalculateCurStageEnemyInfo()
        {
            for(int i = Config.StageEnemyInfos.Count - 1; i >= 0; i--)
            {
                if(Level >= Config.StageEnemyInfos[i].MinLevel)
                {
                    _curStageEnemyInfo = Config.StageEnemyInfos[i];
                    break;
                }
            }
        }

        public void AddSubmitedSansamCount(int count)
        {
            _data.AddSubmitedSansamCount(count);
        }

        public string GetEnemyKey()
        {
            if (_curStageEnemyInfo == null)
                return "Oni_1";

            int index = _curStageEnemyInfo.EnemyRates.Choose();
            return _curStageEnemyInfo.EnemyKeys[index];
        }
        public float GetEnemySpawnSpan()
        {
            if (_curStageEnemyInfo == null)
                return 5.0f;

            return UnityEngine.Random.Range(_curStageEnemyInfo.MinSpawnSpan, _curStageEnemyInfo.MaxSpawnSpan);
        }
    }
}


