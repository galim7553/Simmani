using System.Collections;
using System.Collections.Generic;
using GamePlay.Hubs;
using UnityEngine;

namespace GamePlay.Modules
{
    public class DamageSenderModel : ModuleModelBase<IDamageSenderConfig>, IDamageSenderModel
    {
        public float Damage => Config.BaseDamage;
        HashSet<CharacterTagType> _targetCharacterTagTypeSet;
        public DamageSenderModel(IDamageSenderConfig config) : base(config)
        {
            _targetCharacterTagTypeSet = new HashSet<CharacterTagType>(Config.TargetCharacterTagTypes);
        }        

        public bool GetIsDamageSendable(CharacterTagType characterTagType)
        {
            return _targetCharacterTagTypeSet.Contains(characterTagType);
        }
    }

}

