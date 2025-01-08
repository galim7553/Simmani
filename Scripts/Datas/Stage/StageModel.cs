using System;
using GamePlay.Modules;

namespace GamePlay.Datas
{
    /// <summary>
    /// �������� �����͸� �����ϴ� Ŭ�����Դϴ�.
    /// </summary>
    public class StageModel : DataDependantModelBase<IStageConfig, StageData>, IStageModel
    {
        StageEnemyInfo _curStageEnemyInfo;

        /// <summary>���� �������� ����.</summary>
        public int Level => _data.SansamCounts.Count;

        /// <summary>���� ���������� ��ǥ ��� ����.</summary>
        public int SansamCount => _data.SansamCounts[_data.SansamCounts.Count - 1];

        /// <summary>����� ��� ����.</summary>
        public int SubmitedSansamCount => _data.SubmitedSansamCount;

        /// <summary>���� ��ǥ ��� ����.</summary>
        public int RemainedSansamCount => SansamCount - SubmitedSansamCount;

        /// <summary>���� ���� �̺�Ʈ.</summary>
        public event Action OnLevelChanged;
        
        public StageModel(IStageConfig config, StageData data) : base(config, data)
        {
            AddLevel();
        }

        /// <summary>�������� ������ ������ŵ�ϴ�.</summary>
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


