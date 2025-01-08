using System;

namespace GamePlay.Modules
{
    /// <summary>
    /// ���� �� �ð� �ֱ� ������ �����ϴ� �������̽�.
    /// </summary>
    public interface ITimeCycleModel
    {
        ITimeCycleConfig Config { get; }

        /// <summary>���� ���� �ð�.</summary>
        DateTime DateTime { get; }

        /// <summary>���� ��� �ϼ�.</summary>
        int GameDay { get; }

        /// <summary>�ѱ� ���� �ð� (2�ð� ����).</summary>
        int KoreanHour { get; }

        /// <summary>���� �ϼ��� ǥ���� �ؽ�Ʈ Ű.</summary>
        string GameDayTextKey { get; }

        /// <summary>�ѱ� ���� �ð��� ǥ���� �ؽ�Ʈ Ű.</summary>
        string KoreanHourTextKey { get; }

        /// <summary>�ѱ� ���� �ð��� ��������Ʈ ���.</summary>
        string KoreanHourSpritePath { get; }

        /// <summary>�ð��� ����� �� �߻��ϴ� �̺�Ʈ.</summary>
        event Action OnHourChanged;

        /// <summary>
        /// �ð� �����͸� ������Ʈ.
        /// </summary>
        /// <param name="deltaTime">������ �� ��� �ð�.</param>
        void OnUpdate(float deltaTime);
    }
}