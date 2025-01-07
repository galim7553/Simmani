namespace GamePlay.Modules
{
    /// <summary>
    /// 점프 설정값을 정의하는 인터페이스.
    /// </summary>
    public interface IJumperConfig
    {
        /// <summary>
        /// 점프 타입 (속도 또는 높이 기준).
        /// </summary>
        IJumper.JumpType JumpType { get; }

        /// <summary>
        /// 기본 점프 속도.
        /// </summary>
        float BaseJumpSpeed { get; }

        /// <summary>
        /// 기본 점프 높이.
        /// </summary>
        float BaseJumpHeight { get; }
    }
}
