namespace GamePlay.Datas
{
    /// <summary>
    /// 난이도 설정을 정의하는 인터페이스입니다.
    /// </summary>
    public interface IDifficultyConfig
    {
        public enum DifficultyType
        {
            Easy,
            Normal,
            Difficult
        }
        DifficultyType Type { get; }

        /// <summary>
        /// 산삼 등장 확률(0~1 범위)입니다.
        /// </summary>
        float SansamRate { get; }

        /// <summary>
        /// 최대 Oni(적) 등장 수를 정의합니다.
        /// </summary>
        int MaxOniCount { get; }
    }
}