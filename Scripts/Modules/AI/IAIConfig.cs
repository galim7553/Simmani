using GamePlay.Configs;

namespace GamePlay.Modules.AI
{
    /// <summary>
    /// AI�� �������� �����ϴ� �������̽��Դϴ�.
    /// </summary>
    public interface IAIConfig : IConfig
    {

        /// <summary>AI ���� ������Ʈ ����.</summary>
        float UpdateSpan { get; }
    }
}


