using System;
using GamePlay.Modules;

namespace GamePlay.Datas
{
    /// <summary>
    /// 스테이지 데이터를 관리하는 클래스입니다.
    /// </summary>
    public class StageModel : DataDependantModelBase<IStageConfig, StageData>, IStageModel
    {
        StageEnemyInfo _curStageEnemyInfo;

        /// <summary>현재 스테이지 레벨.</summary>
        public int Level => _data.SansamCounts.Count;

        /// <summary>현재 스테이지의 목표 산삼 개수.</summary>
        public int SansamCount => _data.SansamCounts[_data.SansamCounts.Count - 1];

        /// <summary>제출된 산삼 개수.</summary>
        public int SubmitedSansamCount => _data.SubmitedSansamCount;

        /// <summary>남은 목표 산삼 개수.</summary>
        public int RemainedSansamCount => SansamCount - SubmitedSansamCount;

        /// <summary>레벨 변경 이벤트.</summary>
        public event Action OnLevelChanged;
        
        public StageModel(IStageConfig config, StageData data) : base(config, data)
        {
            AddLevel();
        }

        /// <summary>스테이지 레벨을 증가시킵니다.</summary>
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


