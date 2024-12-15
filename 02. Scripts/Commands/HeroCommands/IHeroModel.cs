using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Commands
{
    public interface IHeroModel
    {
        void ExecuteCommand(IHeroModelCommandConfig.CommandType commandType, float amount);
    }
}


