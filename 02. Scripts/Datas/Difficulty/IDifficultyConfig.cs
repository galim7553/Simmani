namespace GamePlay.Datas
{
    /// <summary>
    /// ���̵� ������ �����ϴ� �������̽��Դϴ�.
    /// </summary>
    public interface IDifficultyConfig
    {
        public enum DifficultyType
        {
            Easy,
            Normal,
            Difficult
        }
        DifficultyType Type { get; }

        /// <summary>
        /// ��� ���� Ȯ��(0~1 ����)�Դϴ�.
        /// </summary>
        float SansamRate { get; }

        /// <summary>
        /// �ִ� Oni(��) ���� ���� �����մϴ�.
        /// </summary>
        int MaxOniCount { get; }
    }
}