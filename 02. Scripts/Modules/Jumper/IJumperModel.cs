namespace GamePlay.Modules
{
    /// <summary>
    /// 점프 데이터를 관리하는 인터페이스.
    /// </summary>
    public interface IJumperModel
    {
        /// <summary>
        /// 점프 타입 (속도 또는 높이 기준).
        /// </summary>
        IJumper.JumpType JumpType { get; }

        /// <summary>
        /// 점프 속도.
        /// </summary>
        float JumpSpeed { get; }

        /// <summary>
        /// 점프 높이.
        /// </summary>
        float JumpHeight { get; }
    }
}
