using UnityEngine;
using GamePlay.Modules;
using System;
using System.Collections.Generic;
using GamePlay.Hubs.Equipments;

namespace GamePlay.Configs
{
    [CreateAssetMenu(fileName = "HeroConfig", menuName = "GameConfig/HeroConfig")]
    public class HeroConfigScriptableObject : ScriptableObject
    {
        [SerializeField] HeroConfig _heroConfig;
        public HeroConfig HeroConfig => _heroConfig;

        private void OnValidate()
        {
            _heroConfig.InvokeOnValidatedEvent();
        }
    }
}