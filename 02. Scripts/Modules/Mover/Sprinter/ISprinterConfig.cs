namespace GamePlay.Modules
{
    /// <summary>
    /// 스프린트 기능에 필요한 설정값을 정의하는 인터페이스.
    /// </summary>
    public interface ISprinterConfig
    {
        /// <summary>
        /// 스프린트 속력.
        /// </summary>
        float SprintSpeed { get; }

        /// <summary>
        /// 기본 스태미너 값.
        /// </summary>
        float Stamina { get; }

        /// <summary>
        /// 스프린트 시 스태미너 소모 속도.
        /// </summary>
        float StaminaConsumptionSpeed { get; }

        /// <summary>
        /// 스프린트가 아닐 때 스태미너 회복 속도.
        /// </summary>
        float StaminaRecoverySpeed { get; }
    }
}