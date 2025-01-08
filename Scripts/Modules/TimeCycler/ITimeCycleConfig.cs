namespace GamePlay.Modules
{
    /// <summary>
    /// ���� �ð� �ֱ��� �������� �����ϴ� �������̽�.
    /// </summary>
    public interface ITimeCycleConfig
    {
        /// <summary>���� �ð� ��� ���� �ð��� ����.</summary>
        float TimeRatio { get; }

        /// <summary>���� ���� �¾� ���� ����.</summary>
        SunInfo NoonSunInfo { get; }

        /// <summary>���� ���� �¾� ���� ����.</summary>
        SunInfo EveningSunInfo { get; }

        /// <summary>�ѹ����� �¾� ���� ����.</summary>
        SunInfo MidnightSunInfo { get; }

        /// <summary>���� �ϼ��� ǥ���� �ؽ�Ʈ Ű ����.</summary>
        string GameDayTextKeyFormat { get; }

        /// <summary>�ѱ� ���� �ð��� ǥ���� �ؽ�Ʈ Ű ����.</summary>
        string KoreanHourTextKeyFormat { get; }

        /// <summary>�ѱ� ���� �ð��� ��������Ʈ ��� ����.</summary>
        string KoreanHourSpritePathFormat { get; }
    }
}
