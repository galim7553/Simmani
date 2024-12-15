using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Commands
{
    public interface IHeroModelCommandConfig : ICommandConfig
    {
        public enum CommandType
        {
            HealHealth,
            HealStamina,
            HealFatigue,
            AddMaxHealth,
            AddMaxStamina,
            AddMaxFatigue,
        }

        public CommandType Type { get;  }
        public float Amount { get; }
    }
}