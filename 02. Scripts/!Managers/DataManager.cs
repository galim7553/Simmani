using GamePlay.Datas;

/// <summary>
/// ���� �����͸� �����ϴ� Ŭ����.
/// TrialData �ν��Ͻ��� �ʱ�ȭ�ϰ� �����ϴ� ������ �մϴ�.
/// </summary>
public class DataManager
{
    /// <summary>
    /// ���� �õ�(Trial) �����͸� �����ϴ� ��ü.
    /// </summary>
    public TrialData TrialData { get; private set; } = new TrialData();

    /// <summary>
    /// DataManager ������.
    /// TrialData�� �ʱ�ȭ�մϴ�.
    /// </summary>
    public DataManager()
    {
    }
}