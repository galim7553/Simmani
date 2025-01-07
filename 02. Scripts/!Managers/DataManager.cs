using GamePlay.Datas;

/// <summary>
/// 게임 데이터를 관리하는 클래스.
/// TrialData 인스턴스를 초기화하고 제공하는 역할을 합니다.
/// </summary>
public class DataManager
{
    /// <summary>
    /// 게임 시도(Trial) 데이터를 관리하는 객체.
    /// </summary>
    public TrialData TrialData { get; private set; } = new TrialData();

    /// <summary>
    /// DataManager 생성자.
    /// TrialData를 초기화합니다.
    /// </summary>
    public DataManager()
    {
    }
}