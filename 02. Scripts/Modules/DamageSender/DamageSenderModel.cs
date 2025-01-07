using System.Collections.Generic;
using GamePlay.Hubs;

namespace GamePlay.Modules
{
    /// <summary>
    /// ������ �������� �� Ŭ����. �������� ���¸� ����.
    /// </summary>
    public class DamageSenderModel : ModuleModelBase<IDamageSenderConfig>, IDamageSenderModel
    {
        /// <summary>
        /// ���� ������ ��.
        /// </summary>
        public float Damage => Config.BaseDamage;

        /// <summary>
        /// �������� �� �� �ִ� ��� �±��� ����.
        /// </summary>
        HashSet<CharacterTagType> _targetCharacterTagTypeSet;

        /// <summary>
        /// ������. �������� ������� ������ ���� ���� �ʱ�ȭ.
        /// </summary>
        /// <param name="config">������ ������ ������.</param>
        public DamageSenderModel(IDamageSenderConfig config) : base(config)
        {
            _targetCharacterTagTypeSet = new HashSet<CharacterTagType>(Config.TargetCharacterTagTypes);
        }

        /// <summary>
        /// Ư�� ĳ���� �±׿� ���� ������ ���� ���� ���θ� ��ȯ.
        /// </summary>
        /// <param name="characterTagType">Ȯ���� ĳ���� �±� Ÿ��.</param>
        /// <returns>������ ���� ���� ����.</returns>
        public bool GetIsDamageSendable(CharacterTagType characterTagType)
        {
            return _targetCharacterTagTypeSet.Contains(characterTagType);
        }
    }

}

