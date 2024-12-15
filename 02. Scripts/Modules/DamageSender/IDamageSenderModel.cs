using System.Collections;
using System.Collections.Generic;
using GamePlay.Hubs;
using UnityEngine;

namespace GamePlay.Modules
{
    public interface IDamageSenderModel
    {
        float Damage {  get; }
        bool GetIsDamageSendable(CharacterTagType characterTagType);
    }
}


