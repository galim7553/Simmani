namespace GamePlay.Commands
{
    /// <summary>
    /// Hero �� ��� ���� �������̽�.
    /// </summary>
    public interface IHeroModelCommandConfig : ICommandConfig
    {
        /// <summary>
        /// Hero �� ��� Ÿ�� ������.
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

        /// <summary>��� Ÿ��.</summary>
        public CommandType Type { get;  }

        /// <summary>��� ���� �� ������ ��.</summary>
        public float Amount { get; }
    }
}