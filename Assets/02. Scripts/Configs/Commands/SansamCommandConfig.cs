using GamePlay.Commands;
using GamePlay.Modules;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Configs
{
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


