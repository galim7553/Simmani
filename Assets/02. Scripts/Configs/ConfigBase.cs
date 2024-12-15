using System;
using UnityEngine;

namespace GamePlay.Configs
{
    public interface IConfig
    {
        public string Key { get; }
    }

    [Serializable]
    public abstract class ConfigBase : IConfig
    {
        [Header("----- Ű -----")]
        [SerializeField] protected string _key;
        public string Key => _key;
    }

    [Serializable]
    public abstract class HubConfigBase : ConfigBase
    {
        [Header("----- ������ -----")]
        [SerializeField] protected string _prefabPath;
        public virtual string PrefabPath => _prefabPath;
    }

    public interface IValidatableConfig
    {
        event Action OnValidated;
        void InvokeOnValidatedEvent();
    }
}


