using System;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Datas
{
    /// <summary>
    /// �������� ���� �����͸� �����ϴ� Ŭ�����Դϴ�.
    /// </summary>
    [Serializable]
    public class StageData
    {
        [SerializeField] List<int> _sansamCounts = new List<int>();
        [SerializeField] int _submitedSansamCount = 0;

        /// <summary>���������� ��� ���� ����Ʈ.</summary>
        public IReadOnlyList<int> SansamCounts => _sansamCounts;

        /// <summary>����� ��� ����.</summary>
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

