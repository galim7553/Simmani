using System.Collections.Generic;
using GamePlay.Hubs;

namespace GamePlay.Modules
{
    /// <summary>
    /// 데미지 송출자의 모델 클래스. 설정값과 상태를 관리.
    /// </summary>
    public class DamageSenderModel : ModuleModelBase<IDamageSenderConfig>, IDamageSenderModel
    {
        /// <summary>
        /// 현재 데미지 값.
        /// </summary>
        public float Damage => Config.BaseDamage;

        /// <summary>
        /// 데미지를 줄 수 있는 대상 태그의 집합.
        /// </summary>
        HashSet<CharacterTagType> _targetCharacterTagTypeSet;

        /// <summary>
        /// 생성자. 설정값을 기반으로 데미지 송출 모델을 초기화.
        /// </summary>
        /// <param name="config">데미지 송출자 설정값.</param>
        public DamageSenderModel(IDamageSenderConfig config) : base(config)
        {
            _targetCharacterTagTypeSet = new HashSet<CharacterTagType>(Config.TargetCharacterTagTypes);
        }

        /// <summary>
        /// 특정 캐릭터 태그에 대해 데미지 송출 가능 여부를 반환.
        /// </summary>
        /// <param name="characterTagType">확인할 캐릭터 태그 타입.</param>
        /// <returns>데미지 송출 가능 여부.</returns>
        public bool GetIsDamageSendable(CharacterTagType characterTagType)
        {
            return _targetCharacterTagTypeSet.Contains(characterTagType);
        }
    }

}

