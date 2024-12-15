using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Modules
{
    public class TimeCycleData
    {
        [SerializeField] long _timeStamp = 471490416000000000;

        DateTime _dateTime;

        public DateTime DateTime => _dateTime;

        public void Initialize()
        {
            _dateTime = new DateTime(_timeStamp);
        }

        public void AddSeconds(double seconds)
        {
            _dateTime = _dateTime.AddSeconds(seconds);
            _timeStamp = _dateTime.Ticks;
        }
        public void SetDateTime(DateTime dateTime)
        {
            _dateTime = dateTime;
        }
    }
}


