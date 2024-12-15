using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Modules
{
    public interface IInteractorDetectorConfig
    {
        float RayDistance { get; }
        LayerMask InteractableLayerMask { get; }
    }
}


