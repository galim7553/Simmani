using System;

namespace GamePlay.Modules
{
    /// <summary>
    /// 전투 상태 관리 모듈 인터페이스.
    /// </summary>
    public interface ICombatStater : IModule
    {
        /// <summary>
        /// 전투 상태를 나타내는 열거형.
        /// </summary>
        public enum CombatState
        {
            Idle,
            Stiffened,
            Attacking
        }
        CombatState State { get; }

        /// <summary>
        /// 특정 전투 상태에 진입할 때 실행할 액션을 추가합니다.
        /// </summary>
        void AddEnterAction(CombatState stateType, Action action);

        /// <summary>
        /// 특정 전투 상태를 종료할 때 실행할 액션을 추가합니다.
        /// </summary>
        void AddExitAction(CombatState stateType, Action action);

        /// <summary>
        /// 전투 상태를 설정합니다.
        /// </summary>
        void SetState(CombatState state);
    }

}

