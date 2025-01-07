namespace GamePlay.Modules.AI
{
    /// <summary>
    /// 추적 가능한 AI의 데이터 모델 인터페이스입니다.
    /// </summary>
    public interface IFollowableAIModel
    {
        /// <summary>속도 비율을 설정합니다.</summary>
        /// <param name="speedRaito">속도 비율 값.</param>
        void SetSpeedRaito(float speedRaito);
    }
}


