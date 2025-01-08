namespace GamePlay.Modules
{
    /// <summary>
    /// 이동 모듈의 설정 데이터를 정의하는 인터페이스.
    /// </summary>
    public interface IMoverConfig
    {
        /// <summary>
        /// 기본 이동 속도.
        /// </summary>
        float BaseSpeed { get; }
    }
}
