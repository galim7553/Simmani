using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamePlay.Datas;

namespace GamePlay.Modules
{
    public class TimeCycleModel : DataDependantModelBase<ITimeCycleConfig, TimeCycleData>, ITimeCycleModel
    {
        readonly DateTime _initDateTime = new DateTime(1495, 2, 4);

        DateTime _lastEventTime;
        public DateTime DateTime => _data.DateTime;

        public int GameDay => (DateTime - _initDateTime).Days;
        public int KoreanHour => ((DateTime.Hour + 1) / 2) % 12;

        public string GameDayTextKey => string.Format(Config.GameDayTextKeyFormat, GameDay % 5);
        public string KoreanHourTextKey => string.Format(Config.KoreanHourTextKeyFormat, KoreanHour);
        public string KoreanHourSpritePath => string.Format(Config.KoreanHourSpritePathFormat, KoreanHour);

        public event Action OnHourChanged;

        
        public TimeCycleModel(ITimeCycleConfig config, TimeCycleData data) : base(config, data)
        {
            _data.Initialize();
        }
        public void SetDateTimeByLevel(int level)
        {
            DateTime newDateTime = _initDateTime;
            newDateTime = newDateTime.AddDays(level * 5);
            newDateTime = newDateTime.AddHours(12);
            _data.SetDateTime(newDateTime);
        }

        public void OnUpdate(float deltaTime)
        {
            _data.AddSeconds(deltaTime * Config.TimeRatio);

            if(DateTime.Hour != _lastEventTime.Hour)
            {
                _lastEventTime = DateTime;
                OnHourChanged?.Invoke();
            }
        }
    }
}


