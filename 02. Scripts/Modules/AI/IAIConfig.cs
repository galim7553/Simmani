using System.Collections;
using System.Collections.Generic;
using GamePlay.Configs;
using UnityEngine;

namespace GamePlay.Modules.AI
{
    public interface IAIConfig : IConfig
    {
        float UpdateSpan { get; }
    }
}


