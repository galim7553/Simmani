using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Modules.AI
{
    public interface IBehaviour
    {
        void Enter();
        void Exit();
        void Clear();
    }
}


