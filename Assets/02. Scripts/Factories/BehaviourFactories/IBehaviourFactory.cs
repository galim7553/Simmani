using System.Collections;
using System.Collections.Generic;
using GamePlay.Modules.AI;
using UnityEngine;

namespace GamePlay.Factories
{
    public interface IBehaviourFactory
    {
        IBehaviour CreateBehaviour(string key, IAI ai);
    }

}

