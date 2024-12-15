using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Modules.AI
{
    public abstract class BehaviourBase<TConfig, TAI> : IBehaviour where TConfig : IBehaviourConfig where TAI : IAI
    {
        protected TConfig _config;
        protected TAI _ai;

        public BehaviourBase(TConfig config, TAI ai)
        {
            _config = config;
            _ai = ai;
        }

        public abstract void Enter();
        public abstract void Exit();
        public virtual void Clear()
        {
        }
    }
}


