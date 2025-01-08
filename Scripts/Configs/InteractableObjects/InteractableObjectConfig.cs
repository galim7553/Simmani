using GamePlay.Modules;
using System;
using UnityEngine;

namespace GamePlay.Configs
{
    /// <summary>
    /// ��ȣ�ۿ� ������ ������Ʈ�� ������ �����ϴ� Ŭ����.
    /// �� ��ȣ�ۿ� ������Ʈ�� ��� Ű�� ���� Ư�� ��ɰ� ����˴ϴ�.
    /// </summary>
    [Serializable]
    public class InteractableObjectConfig : HubConfigBase, IInteractorConfig
    {
        public override string PrefabPath => $"InteractableObjects/{_prefabPath}";
        [Header("----- ��ȣ�ۿ� -----")]

        [SerializeField] string _commandKey = "CollectingSansam";
        public string CommandKey => _commandKey;
        public InteractableObjectConfig()
        {
            _key = "SanSam";
            _prefabPath = "SanSam";
        }

        
    }
}


