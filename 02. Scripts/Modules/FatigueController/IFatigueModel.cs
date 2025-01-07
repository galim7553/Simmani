using System;

namespace GamePlay.Modules
{
    /// <summary>
    /// �Ƿε� �����͸� �����ϴ� �� �������̽�.
    /// </summary>
    public interface IFatigueModel
    {
        /// <summary>
        /// �Ƿε� ���� ������ �����ɴϴ�.
        /// </summary>
        IFatigueConfig Config { get; }

        /// <summary>
        /// �ִ� �Ƿε� ��.
        /// </summary>
        float MaxFatigue { get; }

        /// <summary>
        /// ���� �Ƿε� ��.
        /// </summary>
        float Fatigue { get; }

        /// <summary>
        /// �Ƿε� ��ȭ �� ȣ��Ǵ� �̺�Ʈ.
        /// </summary>
        event Action OnFatigueChanged;

        /// <summary>
        /// �Ƿε��� ����/���ҽ�ŵ�ϴ�.
        /// </summary>
        void AddFatigue(float amount);
    }

}