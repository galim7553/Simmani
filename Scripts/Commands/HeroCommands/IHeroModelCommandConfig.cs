namespace GamePlay.Commands
{
    /// <summary>
    /// Hero 모델 명령 설정 인터페이스.
    /// </summary>
    public interface IHeroModelCommandConfig : ICommandConfig
    {
        /// <summary>
        /// Hero 모델 명령 타입 열거형.
        /// </summary>
        public enum CommandType
        {
            HealHealth,
            HealStamina,
            HealFatigue,
            AddMaxHealth,
            AddMaxStamina,
            AddMaxFatigue,
        }

        /// <summary>명령 타입.</summary>
        public CommandType Type { get;  }

        /// <summary>명령 실행 시 적용할 값.</summary>
        public float Amount { get; }
    }
}