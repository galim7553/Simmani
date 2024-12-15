using GamePlay.Configs;
using GamePlay.Hubs;
using System.Collections.Generic;

namespace GamePlay.Factories
{
    public abstract class FactoryBase<T1, T2> where T1 : ObjectHub
    {
        protected PoolManager _poolManager;
        public FactoryBase(PoolManager poolManager)
        {
            _poolManager = poolManager;
        }

        public abstract T1 Create(T2 model);
    }
}
