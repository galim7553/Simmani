using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Modules
{
    public interface ITimeCycleModel
    {
        ITimeCycleConfig Config { get; }

        DateTime DateTime { get; }
        int GameDay { get; }
        int KoreanHour { get; }

        string GameDayTextKey { get; }
        string KoreanHourTextKey { get; }
        string KoreanHourSpritePath { get; }

        event Action OnHourChanged;

        void OnUpdate(float deltaTime);
    }
}