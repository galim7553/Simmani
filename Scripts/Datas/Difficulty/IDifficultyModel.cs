namespace GamePlay.Datas
{
    /// <summary>
    /// 난이도 모델 인터페이스.
    /// </summary>
    public interface IDifficultyModel
    {
        /// <summary>
        /// 현재 난이도 설정에서 산삼인지 여부를 확률적으로 결정합니다.
        /// </summary>
        /// <returns>산삼 여부</returns>
        bool GetIsSansam();
    }

}