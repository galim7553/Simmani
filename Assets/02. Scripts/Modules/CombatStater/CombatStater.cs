using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GamePlay.Modules.ICombatStater;

namespace GamePlay.Modules
{
    public class CombatStater : ModuleBase, ICombatStater, IUpdatable
    {

        public ICombatStaterModel Model { get; private set; }

        public CombatState State => _curState.State;

        IState _curState;
        IState[] _states;

        Action[] _enterActions;
        Action[] _exitActions;

        public CombatStater(ICombatStaterModel model)
        {
            Model = model;

            _states = new IState[Enum.GetValues(typeof(CombatState)).Length];
            for (int i = 0; i < _states.Length; i++)
                _states[i] = StateBase.CreateState((CombatState)i, this);
            _curState = _states[0];

            _enterActions = new Action[_states.Length];
            _exitActions = new Action[_states.Length];
        }

        public void OnUpdate()
        {
            if (_curState != null)
                _curState.Update(Time.deltaTime);
        }

        public void AddEnterAction(CombatState stateType, Action action)
        {
            _enterActions[(int)stateType] += action;
        }
        public void AddExitAction(CombatState stateType, Action action)
        {
            _exitActions[(int)stateType] += action;
        }

        public void SetState(CombatState state)
        {
            int index = (int)state;
            if (index < 0 || index >= _states.Length) return;

            if (_curState != null)
                _curState.Exit();

            _curState = _states[index];
            _curState.Enter();
        }

        public void InvokeEnterActions(CombatState stateType)
        {
            _enterActions[(int)stateType]?.Invoke();
        }
        public void InvokeExitActions(CombatState stateType)
        {
            _exitActions[(int)stateType]?.Invoke();
        }


        public override void Clear()
        {
            base.Clear();

            for (int i = 0; i < _enterActions.Length; i++)
            {
                _enterActions[i] = null;
                _exitActions[i] = null;
            }
        }

        public interface IState
        {
            CombatState State { get; }
            void Enter();
            void Update(float deltaTime);
            void Exit();
        }
        public abstract class StateBase : IState
        {
            public static IState CreateState(CombatState stateType, CombatStater combatStater)
            {
                switch (stateType)
                {
                    case CombatState.Stiffened:
                        return new StiffenedState(combatStater);
                    case CombatState.Attacking:
                        return new AttackingState(combatStater);
                    default:
                        return new IdleState(combatStater);
                }
            }


            protected CombatStater _combatStater;

            public abstract CombatState State { get; }
            public StateBase(CombatStater stater)
            {
                _combatStater = stater;
            }

            public virtual void Enter()
            {
                _combatStater.InvokeEnterActions(State);
            }
            public abstract void Update(float deltaTime);
            public virtual void Exit()
            {
                _combatStater.InvokeExitActions(State);
            }
        }

        public class IdleState : StateBase
        {
            public override CombatState State => CombatState.Idle;
            public IdleState(CombatStater stater) : base(stater)
            {
            }
            public override void Enter()
            {
                base.Enter();
            }

            public override void Exit()
            {
                base.Exit();
            }

            public override void Update(float deltaTime)
            {
                
            }
        }
        public class StiffenedState : StateBase
        {
            public override CombatState State => CombatState.Stiffened;

            float _elapsedTime = 0.0f;
            public StiffenedState(CombatStater stater) : base(stater)
            {
            }

            public override void Enter()
            {
                base.Enter();
                _elapsedTime = 0.0f;
            }
            public override void Update(float deltaTime)
            {
                _elapsedTime += deltaTime;
                if (_elapsedTime > _combatStater.Model.Config.StiffenTime)
                    _combatStater.SetState(CombatState.Idle);
            }
        }
        public class AttackingState : StateBase
        {
            public override CombatState State => CombatState.Attacking;

            float _elapsedTime = 0.0f;
            public AttackingState(CombatStater stater) : base(stater)
            {
            }

            public override void Enter()
            {
                base.Enter();

                _elapsedTime = 0.0f;
            }

            public override void Update(float deltaTime)
            {
                _elapsedTime += deltaTime;
                if (_elapsedTime > _combatStater.Model.Config.AttackingTime)
                    _combatStater.SetState(CombatState.Idle);
            }
        }
    }
}


