using System.Collections;
using System.Collections.Generic;
using GamePlay.Hubs;
using UnityEngine;

namespace GamePlay
{
    public interface IModuleHolder
    {
        ModuleContainer Modules { get; }
    }
}