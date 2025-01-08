using System;
using UnityEngine;

namespace GamePlay.Modules
{
    /// <summary>
    /// 게임 내 시간 데이터를 관리하는 클래스.
    /// </summary>
    public class TimeCycleData
    {
        [SerializeField] long _timeStamp = 471490416000000000;

        DateTime _dateTime;

        /// <summary>게임 내 현재 시각.</summary>
        public DateTime DateTime => _dateTime;

        /// <summary>
        /// 데이터를 초기화하여 기본 타임스탬프를 DateTime으로 변환.
        /// </summary>
        public void Initialize()
        {
            _dateTime = new DateTime(_timeStamp);
        }

        /// <summary>
        /// 시간 데이터를 초 단위로 추가.
        /// </summary>
        /// <param name="seconds">추가할 초.</param>
        public void AddSeconds(double seconds)
        {
            _dateTime = _dateTime.AddSeconds(seconds);
            _timeStamp = _dateTime.Ticks;
        }

        /// <summary>
        /// 새로운 게임 시각을 설정.
        /// </summary>
        /// <param name="dateTime">설정할 DateTime 값.</param>
        public void SetDateTime(DateTime dateTime)
        {
            _dateTime = dateTime;
        }
    }
}


