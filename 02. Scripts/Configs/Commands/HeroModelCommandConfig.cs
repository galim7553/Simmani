using GamePlay.Commands;
using System;
using UnityEngine;

namespace GamePlay.Configs
{
    /// <summary>
    /// HeroModel�� ����Ǵ� ��� ������ �����ϴ� Ŭ�����Դϴ�.
    /// ��� ������ ��ġ�� �����մϴ�.
    /// </summary>
    [Serializable]
    public class HeroModelCommandConfig : ConfigBase, IHeroModelCommandConfig
    {
        [Header("----- ��� -----")]
        [SerializeField] IHeroModelCommandConfig.CommandType _commandType = IHeroModelCommandConfig.CommandType.HealHealth;
        [SerializeField] float _amount = 0;
        public IHeroModelCommandConfig.CommandType Type => _commandType;
        public float Amount => _amount;
    }
}
