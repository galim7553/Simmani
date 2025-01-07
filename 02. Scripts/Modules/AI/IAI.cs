using GamePlay.Hubs;
using UnityEngine;

namespace GamePlay.Modules.AI
{
    /// <summary>
    /// AI�� �⺻ �������̽���, �������� AI ���۰� �Ӽ��� �����մϴ�.
    /// </summary>
    public interface IAI
    {
        /// <summary>AI�� �����ϴ� ���� Ű.</summary>
        string Key { get; }

        /// <summary>AI�� �����ϴ� Transform.</summary>
        Transform Transform { get; }

        /// <summary>AI���� ����� Coroutine Runner.</summary>
        ICoroutineRunner CoroutineRunner { get; }

        /// <summary>AI ���� ������Ʈ ����.</summary>
        float UpdateSpan { get; }

        /// <summary>AI ������ �����մϴ�.</summary>
        void Start();

        /// <summary>AI ������ �����մϴ�.</summary>
        void Stop();

        /// <summary>AI ������ �Ͻ� �����ϰų� �ٽ� �����մϴ�.</summary>
        /// <param name="isPause">true�̸� �Ͻ� ����, false�̸� �ٽ� ����.</param>
        void Pause(bool isPause);
    }
}


