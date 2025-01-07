using GamePlay.Commands;
using GamePlay.Modules;
using System;
using UnityEngine;

namespace GamePlay.Configs
{
    /// <summary>
    /// ��� ��ȣ�ۿ� ��ɿ� ���� ������ �����ϴ� Ŭ�����Դϴ�.
    /// ���μ��� ��, ��� ������ Ű ���� �����մϴ�.
    /// </summary>
    [Serializable]
    public class SansamCommandConfig : ConfigBase, ISansamCommandConfig
    {
        [Header("----- ��� ��ȣ�ۿ� -----")]
        [SerializeField] float _processAmount = 3.0f;
        [SerializeField] string _sansamItemKey = "SanSam";
        [SerializeField] string _notSansamItemKey = "DeoDeok";

        public float ProcessAmount => _processAmount;
        public string SansamItemKey => _sansamItemKey;
        public string NotSansamItemKey => _notSansamItemKey;
        public IProcessable.ProcessType ProcessType => IProcessable.ProcessType.Loot;        
    }
}


