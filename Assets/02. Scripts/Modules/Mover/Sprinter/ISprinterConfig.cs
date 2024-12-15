using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Modules
{
    public interface ISprinterConfig
    {
        float SprintSpeed { get; }
        float Stamina { get; }
        float StaminaConsumptionSpeed { get; }
        float StaminaRecoverySpeed { get; }
    }
}


