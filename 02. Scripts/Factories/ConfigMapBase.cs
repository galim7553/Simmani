using System.Collections;
using System.Collections.Generic;
using GamePlay.Configs;
using UnityEngine;

namespace GamePlay.Factories
{
    public abstract class ConfigMapBase<TConfig> where TConfig : IConfig
    {
        protected Dictionary<string, TConfig> _configMap = new Dictionary<string, TConfig>();

        public ConfigMapBase(IEnumerable<TConfig> configs)
        {
            foreach (var config in configs)
                _configMap[config.Key] = config;
        }

        protected void LogMissingConfig(string key)
        {
            Debug.LogError($"{key} {typeof(TConfig)}는(은) 존재하지 않습니다.");
        }
    }
}