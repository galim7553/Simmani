using GamePlay.Hubs;

namespace GamePlay.Modules
{
    /// <summary>
    /// �ǰ� �ý����� �������� �����ϴ� �������̽�.
    /// </summary>
    public interface IDamageReceiverConfig
    {
        /// <summary>
        /// ĳ������ �±� Ÿ��.
        /// </summary>
        CharacterTagType CharacterTagType { get; }

        /// <summary>
        /// ĳ������ �⺻ ü��.
        /// </summary>
        float BaseHealth { get; }
    }
}