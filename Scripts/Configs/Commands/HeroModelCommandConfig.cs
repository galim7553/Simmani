using GamePlay.Commands;
using System;
using UnityEngine;

namespace GamePlay.Configs
{
    /// <summary>
    /// HeroModel에 적용되는 명령 설정을 정의하는 클래스입니다.
    /// 명령 유형과 수치를 제공합니다.
    /// </summary>
    [Serializable]
    public class HeroModelCommandConfig : ConfigBase, IHeroModelCommandConfig
    {
        [Header("----- 명령 -----")]
        [SerializeField] IHeroModelCommandConfig.CommandType _commandType = IHeroModelCommandConfig.CommandType.HealHealth;
        [SerializeField] float _amount = 0;
        public IHeroModelCommandConfig.CommandType Type => _commandType;
        public float Amount => _amount;
    }
}
