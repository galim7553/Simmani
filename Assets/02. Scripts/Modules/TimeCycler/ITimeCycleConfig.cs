using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Modules
{
    public interface ITimeCycleConfig
    {
        float TimeRatio { get; }
        
        SunInfo NoonSunInfo { get; }
        SunInfo EveningSunInfo { get; }
        SunInfo MidnightSunInfo { get; }

        string GameDayTextKeyFormat { get; }
        string KoreanHourTextKeyFormat { get; }
        string KoreanHourSpritePathFormat { get; }

    }

}

