using GamePlay.Modules;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Scene
{
    public interface ITerrainCullerModel
    {
        float UpdateSpan { get; }
        float Threshold { get; }
    }
}
