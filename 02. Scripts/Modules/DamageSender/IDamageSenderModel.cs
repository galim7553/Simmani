using GamePlay.Hubs;

namespace GamePlay.Modules
{
    /// <summary>
    /// ������ �������� ���� �����ϴ� �������̽�.
    /// </summary>
    public interface IDamageSenderModel
    {
        /// <summary>
        /// ���� ������ ��.
        /// </summary>
        float Damage {  get; }

        /// <summary>
        /// Ư�� ĳ���� �±׿� ���� ������ ���� ���� ���θ� ��ȯ.
        /// </summary>
        /// <param name="characterTagType">Ȯ���� ĳ���� �±� Ÿ��.</param>
        /// <returns>������ ���� ���� ����.</returns>
        bool GetIsDamageSendable(CharacterTagType characterTagType);
    }
}


