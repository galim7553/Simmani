namespace GamePlay.Modules
{
    /// <summary>
    /// 추적 모델 인터페이스.
    /// </summary>
    public interface IFollowerModel
    {
        IFollowerConfig Config { get; }

        /// <summary>추적 속도.</summary>
        float Speed { get; }

        /// <summary>회전 속도.</summary>
        float AngularSpeed { get; }
    }

}