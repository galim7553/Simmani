using GamePlay.Modules;
using GamePlay.Modules.AI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Configs
{
    [Serializable]
    public class InteractableObjectConfig : HubConfigBase, IInteractorConfig
    {
        public override string PrefabPath => $"InteractableObjects/{_prefabPath}";
        [Header("----- 상호작용 -----")]

        [SerializeField] string _commandKey = "CollectingSansam";
        public string CommandKey => _commandKey;
        public InteractableObjectConfig()
        {
            _key = "SanSam";
            _prefabPath = "SanSam";
        }

        
    }
}


