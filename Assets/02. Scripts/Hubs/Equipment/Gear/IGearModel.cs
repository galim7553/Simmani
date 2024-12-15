using GamePlay.Configs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Hubs.Equipments
{
    public interface IGearModel
    {
        GearConfig Config { get; }
    }
}
