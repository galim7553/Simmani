namespace GamePlay.Modules
{
    /// <summary>
    /// 게임 시간 주기의 설정값을 정의하는 인터페이스.
    /// </summary>
    public interface ITimeCycleConfig
    {
        /// <summary>실제 시간 대비 게임 시간의 비율.</summary>
        float TimeRatio { get; }

        /// <summary>정오 시의 태양 관련 정보.</summary>
        SunInfo NoonSunInfo { get; }

        /// <summary>저녁 시의 태양 관련 정보.</summary>
        SunInfo EveningSunInfo { get; }

        /// <summary>한밤중의 태양 관련 정보.</summary>
        SunInfo MidnightSunInfo { get; }

        /// <summary>게임 일수를 표시할 텍스트 키 형식.</summary>
        string GameDayTextKeyFormat { get; }

        /// <summary>한국 전통 시간을 표시할 텍스트 키 형식.</summary>
        string KoreanHourTextKeyFormat { get; }

        /// <summary>한국 전통 시간의 스프라이트 경로 형식.</summary>
        string KoreanHourSpritePathFormat { get; }
    }
}
