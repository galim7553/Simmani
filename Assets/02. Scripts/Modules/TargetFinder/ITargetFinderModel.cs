using System.Collections;
using System.Collections.Generic;
using GamePlay.Hubs;
using UnityEngine;

namespace GamePlay.Modules
{
    public interface ITargetFinderModel
    {
        ITargetFinderConfig Config { get; }
        bool GetIsTargetTag(CharacterTagType tagType);
        int GetTagPriority(CharacterTagType tagType);
        
    }

}

