namespace GamePlay.Modules
{
    /// <summary>
    /// 피로도 설정 정보를 정의하는 인터페이스.
    /// </summary>
    public interface IFatigueConfig
    {
        /// <summary>
        /// 초기 피로도 값.
        /// </summary>
        float Fatigue { get; }

        /// <summary>
        /// 피로도 감소 속도(초당 감소량).
        /// </summary>
        float FatigueConsumptionSpeed { get; }
    }
}


