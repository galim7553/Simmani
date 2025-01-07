using GamePlay.Hubs;

namespace GamePlay.Modules
{
    /// <summary>
    /// Ÿ�� Ž�� �� �������̽�.
    /// </summary>
    public interface ITargetFinderModel
    {
        ITargetFinderConfig Config { get; }

        /// <summary>Ư�� �±װ� Ÿ�ٿ� �ش��ϴ��� Ȯ��.</summary>
        bool GetIsTargetTag(CharacterTagType tagType);

        /// <summary>Ư�� �±��� �켱������ ������.</summary>
        int GetTagPriority(CharacterTagType tagType);
        
    }

}

