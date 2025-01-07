using System;
using UnityEngine;

namespace GamePlay.Modules
{
    /// <summary>
    /// ���� �� �ð� �����͸� �����ϴ� Ŭ����.
    /// </summary>
    public class TimeCycleData
    {
        [SerializeField] long _timeStamp = 471490416000000000;

        DateTime _dateTime;

        /// <summary>���� �� ���� �ð�.</summary>
        public DateTime DateTime => _dateTime;

        /// <summary>
        /// �����͸� �ʱ�ȭ�Ͽ� �⺻ Ÿ�ӽ������� DateTime���� ��ȯ.
        /// </summary>
        public void Initialize()
        {
            _dateTime = new DateTime(_timeStamp);
        }

        /// <summary>
        /// �ð� �����͸� �� ������ �߰�.
        /// </summary>
        /// <param name="seconds">�߰��� ��.</param>
        public void AddSeconds(double seconds)
        {
            _dateTime = _dateTime.AddSeconds(seconds);
            _timeStamp = _dateTime.Ticks;
        }

        /// <summary>
        /// ���ο� ���� �ð��� ����.
        /// </summary>
        /// <param name="dateTime">������ DateTime ��.</param>
        public void SetDateTime(DateTime dateTime)
        {
            _dateTime = dateTime;
        }
    }
}


