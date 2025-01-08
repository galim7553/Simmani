using System;

namespace GamePlay.Modules
{
    /// <summary>
    /// ���� ���� ���� ��� �������̽�.
    /// </summary>
    public interface ICombatStater : IModule
    {
        /// <summary>
        /// ���� ���¸� ��Ÿ���� ������.
        /// </summary>
        public enum CombatState
        {
            Idle,
            Stiffened,
            Attacking
        }
        CombatState State { get; }

        /// <summary>
        /// Ư�� ���� ���¿� ������ �� ������ �׼��� �߰��մϴ�.
        /// </summary>
        void AddEnterAction(CombatState stateType, Action action);

        /// <summary>
        /// Ư�� ���� ���¸� ������ �� ������ �׼��� �߰��մϴ�.
        /// </summary>
        void AddExitAction(CombatState stateType, Action action);

        /// <summary>
        /// ���� ���¸� �����մϴ�.
        /// </summary>
        void SetState(CombatState state);
    }

}

