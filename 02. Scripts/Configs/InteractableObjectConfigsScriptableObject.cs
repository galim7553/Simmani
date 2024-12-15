using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Configs
{
    [CreateAssetMenu(fileName = "InteractableObjectConfigs", menuName = "GameConfig/InteractableObjectConfigs")]
    public class InteractableObjectConfigsScriptableObject : ScriptableObject
    {
        [SerializeField] List<InteractableObjectConfig> _interactableObjectConfigs;
        public IReadOnlyList<InteractableObjectConfig> InteractableObjectConfigs => _interactableObjectConfigs;
    }
}


