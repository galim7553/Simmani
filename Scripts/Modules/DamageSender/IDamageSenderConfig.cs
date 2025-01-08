using System.Collections.Generic;
using GamePlay.Hubs;

namespace GamePlay.Modules
{
    /// <summary>
    /// ������ �������� �������� �����ϴ� �������̽�.
    /// </summary>
    public interface IDamageSenderConfig
    {
        /// <summary>
        /// �⺻ ������ ��.
        /// </summary>
        float BaseDamage { get; }

        /// <summary>
        /// �������� �� �� �ִ� ����� �±� Ÿ�� ���.
        /// </summary>
        IReadOnlyList<CharacterTagType> TargetCharacterTagTypes { get; }
    }
}