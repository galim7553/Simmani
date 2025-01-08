using GamePlay.Modules.AI;

namespace GamePlay.Factories
{
    /// <summary>
    /// AI 행동(Behaviour)을 생성하는 팩토리 인터페이스.
    /// </summary>
    public interface IBehaviourFactory
    {
        /// <summary>
        /// 주어진 키와 AI 인스턴스를 기반으로 행동(Behaviour)을 생성합니다.
        /// </summary>
        /// <param name="key">행동의 키 값.</param>
        /// <param name="ai">행동을 수행할 AI 인스턴스.</param>
        /// <returns>생성된 행동 인스턴스.</returns>
        IBehaviour CreateBehaviour(string key, IAI ai);
    }

}

