using System.Collections;
using System.Collections.Generic;
using GamePlay.Hubs;
using UnityEngine;


namespace GamePlay.Modules
{
    public interface IDamageReceiverConfig
    {
        CharacterTagType CharacterTagType { get; }
        float BaseHealth { get; }
    }

}
