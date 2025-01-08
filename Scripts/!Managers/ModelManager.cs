using GamePlay.Datas;
using GamePlay;

/// <summary>
/// ���� ���� �����ϴ� Ŭ����.
/// WorldModel �ν��Ͻ��� �ʱ�ȭ�ϰ� �����մϴ�.
/// </summary>
public class ModelManager
{
    /// <summary>
    /// ������ ���� ���¸� �����ϴ� WorldModel �ν��Ͻ�.
    /// </summary>
    public WorldModel WorldModel { get; private set; }

    /// <summary>
    /// ModelManager ������.
    /// WorldModel�� �ʱ�ȭ�մϴ�.
    /// </summary>
    /// <param name="configManager">���� ���� �����͸� �����ϴ� ConfigManager</param>
    /// <param name="trialData">���� ������ TrialData</param>
    /// <param name="conversationMap">��ȭ �����͸� �����ϴ� IConversationMap</param>
    public ModelManager(ConfigManager configManager, TrialData trialData, IConversationMap conversationMap)
    {
        WorldModel = new WorldModel(configManager, trialData, conversationMap);
    }
}