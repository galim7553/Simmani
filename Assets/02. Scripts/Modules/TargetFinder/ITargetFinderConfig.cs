using System.Collections;
using System.Collections.Generic;
using GamePlay.Hubs;
using UnityEngine;

namespace GamePlay.Modules
{
    public interface ITargetFinderConfig
    {

        LayerMask TargetLayerMask { get; }
        IReadOnlyList<CharacterTagType> TargetTags { get; }
        int DetectionCountLimit { get; }
    }
}