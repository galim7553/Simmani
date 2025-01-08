using GamePlay.Modules;

namespace GamePlay.Commands
{
    /// <summary>
    /// ��� ��� ���� �������̽�.
    /// </summary>
    public interface ISansamCommandConfig : ICommandConfig
    {
        /// <summary>���μ����� �ʿ��� �ð�.</summary>
        float ProcessAmount { get; }

        /// <summary>���μ��� ����.</summary>
        IProcessable.ProcessType ProcessType { get; }

        /// <summary>��� ������ Ű.</summary>
        string SansamItemKey { get; }

        /// <summary>����� �ƴ� ���� ������ Ű.</summary>
        string NotSansamItemKey { get;}
    }
}


