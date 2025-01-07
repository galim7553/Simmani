namespace GamePlay.Modules
{
    /// <summary>
    /// 이동 모듈의 런타임 데이터를 정의하는 인터페이스.
    /// </summary>
    public interface IMoverModel
    {
        /// <summary>
        /// 현재 이동 속도.
        /// </summary>
        float Speed { get; }
    }
}