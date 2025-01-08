using GamePlay.Modules;
using System;
using UnityEngine;

namespace GamePlay.Configs
{
    /// <summary>
    /// 마을 주민(Villager) 캐릭터의 설정 정보를 정의하는 클래스입니다.
    /// 기본 상호작용 설정 값을 제공합니다.
    /// </summary>
    [Serializable]
    public class VillagerConfig : HubConfigBase, IInteractorConfig
    {
        public override string PrefabPath => $"Characters/Villagers/{_prefabPath}";

        [Header("----- 상호작용 -----")]
        [SerializeField] string _commandKey = "TestConversation";
        public string CommandKey => _commandKey;

        public VillagerConfig()
        {
            _prefabPath = "DefaultVillager";
        }
    }

}