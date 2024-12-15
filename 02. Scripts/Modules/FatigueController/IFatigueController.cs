using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Modules
{
    public interface IFatigueController : IModule
    {
        event Action OnFatigueEmpty;
    }

}

