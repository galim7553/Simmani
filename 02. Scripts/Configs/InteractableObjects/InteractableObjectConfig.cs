using GamePlay.Modules;
using System;
using UnityEngine;

namespace GamePlay.Configs
{
    /// <summary>
    /// 상호작용 가능한 오브젝트의 설정을 정의하는 클래스.
    /// 각 상호작용 오브젝트는 명령 키를 통해 특정 명령과 연결됩니다.
    /// </summary>
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


