using System;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Datas
{
    /// <summary>
    /// 스테이지 진행 데이터를 저장하는 클래스입니다.
    /// </summary>
    [Serializable]
    public class StageData
    {
        [SerializeField] List<int> _sansamCounts = new List<int>();
        [SerializeField] int _submitedSansamCount = 0;

        /// <summary>스테이지별 산삼 개수 리스트.</summary>
        public IReadOnlyList<int> SansamCounts => _sansamCounts;

        /// <summary>제출된 산삼 개수.</summary>
        public int SubmitedSansamCount => _submitedSansamCount;

        public void AddSansamCount(int sansamCount)
        {
            _sansamCounts.Add(sansamCount);
        }
        public void AddSubmitedSansamCount(int count)
        {
            _submitedSansamCount += count;
        }
        public void SetSubmitedSansamCount(int count)
        {
            _submitedSansamCount = count;
        }
    }
}

