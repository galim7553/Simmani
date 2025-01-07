using GamePlay.Modules;
using System;
using UnityEngine;

namespace GamePlay.Configs
{
    /// <summary>
    /// ���� �ֹ�(Villager) ĳ������ ���� ������ �����ϴ� Ŭ�����Դϴ�.
    /// �⺻ ��ȣ�ۿ� ���� ���� �����մϴ�.
    /// </summary>
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