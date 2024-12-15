using GamePlay.Configs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Hubs
{
    public abstract class HubModelBase<T> where T : HubConfigBase
    {
        public string PrefabPath => Config.PrefabPath;
        public T Config { get; protected set; }
        public HubModelBase(T config)
        {
            Config = config;

            if (Config is IValidatableConfig validatable)
                validatable.OnValidated += OnValidated;
        }
        protected virtual void OnValidated()
        {

        }
    }
}