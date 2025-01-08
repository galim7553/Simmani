namespace GamePlay.Modules
{
    /// <summary>
    /// ������Ʈ ��ɿ� �ʿ��� �������� �����ϴ� �������̽�.
    /// </summary>
    public interface ISprinterConfig
    {
        /// <summary>
        /// ������Ʈ �ӷ�.
        /// </summary>
        float SprintSpeed { get; }

        /// <summary>
        /// �⺻ ���¹̳� ��.
        /// </summary>
        float Stamina { get; }

        /// <summary>
        /// ������Ʈ �� ���¹̳� �Ҹ� �ӵ�.
        /// </summary>
        float StaminaConsumptionSpeed { get; }

        /// <summary>
        /// ������Ʈ�� �ƴ� �� ���¹̳� ȸ�� �ӵ�.
        /// </summary>
        float StaminaRecoverySpeed { get; }
    }
}