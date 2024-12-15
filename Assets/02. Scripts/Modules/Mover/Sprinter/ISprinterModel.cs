using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Modules
{
    public interface ISprinterModel
    {
        ISprinterConfig Config { get; }
        bool IsSprinting { get; }
        float MaxStamina { get; }
        float Stamina { get; }
        event Action OnStaminaChanged;
        void SetIsSprinting(bool isSprinting);
        void AddStamina(float amount);
    }
}


