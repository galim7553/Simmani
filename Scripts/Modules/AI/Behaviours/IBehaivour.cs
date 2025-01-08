namespace GamePlay.Modules.AI
{

    /// <summary>
    /// AI 행동(Behaviour)의 기본 인터페이스입니다.
    /// </summary>
    public interface IBehaviour
    {
        /// <summary>행동 시작 시 호출됩니다.</summary>
        void Enter();

        /// <summary>행동 종료 시 호출됩니다.</summary>
        void Exit();
        void Clear();
    }
}


