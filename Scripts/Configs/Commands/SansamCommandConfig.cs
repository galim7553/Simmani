using GamePlay.Commands;
using GamePlay.Modules;
using System;
using UnityEngine;

namespace GamePlay.Configs
{
    /// <summary>
    /// 산삼 상호작용 명령에 대한 설정을 정의하는 클래스입니다.
    /// 프로세스 양, 산삼 아이템 키 등을 제공합니다.
    /// </summary>
    [Serializable]
    public class SansamCommandConfig : ConfigBase, ISansamCommandConfig
    {
        [Header("----- 산삼 상호작용 -----")]
        [SerializeField] float _processAmount = 3.0f;
        [SerializeField] string _sansamItemKey = "SanSam";
        [SerializeField] string _notSansamItemKey = "DeoDeok";

        public float ProcessAmount => _processAmount;
        public string SansamItemKey => _sansamItemKey;
        public string NotSansamItemKey => _notSansamItemKey;
        public IProcessable.ProcessType ProcessType => IProcessable.ProcessType.Loot;        
    }
}


