using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using static GamePlay.Modules.CombatStater;

namespace GamePlay.Modules
{
    public interface ICombatStater : IModule
    {
        public enum CombatState
        {
            Idle,
            Stiffened,
            Attacking
        }
        CombatState State { get; }
        void AddEnterAction(CombatState stateType, Action action);
        void AddExitAction(CombatState stateType, Action action);
        void SetState(CombatState state);
    }

}

