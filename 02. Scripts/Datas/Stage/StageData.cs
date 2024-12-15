using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Datas
{
    [Serializable]
    public class StageData
    {
        [SerializeField] List<int> _sansamCounts = new List<int>();
        [SerializeField] int _submitedSansamCount = 0;
        public IReadOnlyList<int> SansamCounts => _sansamCounts;
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

