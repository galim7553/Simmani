namespace GamePlay.Modules
{
    /// <summary>
    /// 회전 모듈의 설정 데이터를 정의하는 인터페이스.
    /// </summary>
    public interface IRotatorConfig
    {
        /// <summary>
        /// 기본 회전 속도.
        /// </summary>
        float BaseRotSpeed { get; }

        /// <summary>
        /// 회전 제한 데이터.
        /// </summary>
        RotatorLimiter RotatorLimiter { get; }
    }
}