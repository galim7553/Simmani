using GamePlay.Modules;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Configs
{
    [Serializable]
    public class VillagerConfig : HubConfigBase, IInteractorConfig
    {
        public override string PrefabPath => $"Characters/Villagers/{_prefabPath}";

        [Header("----- ��ȣ�ۿ� -----")]
        [SerializeField] string _commandKey = "TestConversation";
        public string CommandKey => _commandKey;

        public VillagerConfig()
        {
            _prefabPath = "DefaultVillager";
        }
    }

}