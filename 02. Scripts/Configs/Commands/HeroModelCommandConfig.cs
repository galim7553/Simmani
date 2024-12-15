using GamePlay.Commands;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Configs
{
    [Serializable]
    public class HeroModelCommandConfig : ConfigBase, IHeroModelCommandConfig
    {
        [Header("----- ¸í·É -----")]
        [SerializeField] IHeroModelCommandConfig.CommandType _commandType = IHeroModelCommandConfig.CommandType.HealHealth;
        [SerializeField] float _amount = 0;
        public IHeroModelCommandConfig.CommandType Type => _commandType;
        public float Amount => _amount;
    }
}
