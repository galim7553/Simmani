namespace GamePlay.Modules
{
    /// <summary>
    /// 전투 상태의 설정 데이터를 정의하는 인터페이스.
    /// </summary>
    public interface ICombatStaterConfig
    {
        float StiffenTime { get; } // 경직 상태 지속 시간
        float AttackingTime { get; } // 공격 상태 지속 시간
    }
}


