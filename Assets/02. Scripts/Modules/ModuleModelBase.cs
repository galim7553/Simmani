using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Modules
{
    public abstract class ModuleModelBase<TConfig>
    {
        public TConfig Config { get; protected set; }

        public ModuleModelBase(TConfig config)
        {
            Config = config;
        }
    }
    public abstract class DataDependantModelBase<TConfig, TData> : ModuleModelBase<TConfig>
    {
        protected TData _data;
        public DataDependantModelBase(TConfig config, TData data) : base(config)
        {
            _data = data;
        }
    }
}


