using GamePlay.Datas;
using GamePlay;

/// <summary>
/// 게임 모델을 관리하는 클래스.
/// WorldModel 인스턴스를 초기화하고 관리합니다.
/// </summary>
public class ModelManager
{
    /// <summary>
    /// 게임의 전역 상태를 관리하는 WorldModel 인스턴스.
    /// </summary>
    public WorldModel WorldModel { get; private set; }

    /// <summary>
    /// ModelManager 생성자.
    /// WorldModel을 초기화합니다.
    /// </summary>
    /// <param name="configManager">게임 설정 데이터를 관리하는 ConfigManager</param>
    /// <param name="trialData">현재 게임의 TrialData</param>
    /// <param name="conversationMap">대화 데이터를 제공하는 IConversationMap</param>
    public ModelManager(ConfigManager configManager, TrialData trialData, IConversationMap conversationMap)
    {
        WorldModel = new WorldModel(configManager, trialData, conversationMap);
    }
}