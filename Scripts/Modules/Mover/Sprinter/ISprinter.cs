namespace GamePlay.Modules
{
    /// <summary>
    /// ������Ʈ ����� �����ϴ� ����� �������̽�.
    /// </summary>
    public interface ISprinter : IModule
    {
        /// <summary>
        /// ������Ʈ ���¸� �����մϴ�.
        /// </summary>
        /// <param name="isSprinting">������Ʈ ����</param>
        void SetIsSprinting(bool isSprinting);
    }
}
