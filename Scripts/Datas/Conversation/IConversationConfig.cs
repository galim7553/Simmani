namespace GamePlay.Datas
{
    /// <summary>
    /// 대화 설정 인터페이스. 대화 진행에 필요한 구성값을 정의합니다.
    /// </summary>
    public interface IConversationConfig
    {
        /// <summary>
        /// 글자가 표시되는 간격(초 단위)입니다.
        /// </summary>
        float LetterSpan { get; }
    }
}