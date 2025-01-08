namespace GamePlay.Modules
{
    /// <summary>
    /// 전투 상태의 런타임 데이터를 정의하는 인터페이스.
    /// </summary>
    public interface ICombatStaterModel
    {
        ICombatStaterConfig Config { get; }
    }

}

