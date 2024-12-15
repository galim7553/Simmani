using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Modules
{
    public interface IFatigueModel
    {
        IFatigueConfig Config { get; }
        float MaxFatigue { get; }
        float Fatigue { get; }
        event Action OnFatigueChanged;

        void AddFatigue(float amount);
    }

}