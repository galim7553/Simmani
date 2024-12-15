using GamePlay.Hubs;
using GamePlay.Factories;
using GamePlay.Scene;
using GamePlay.Datas;
using GamePlay.Modules;
using GamePlay;

public class ModelManager
{
    public WorldModel WorldModel { get; private set; }

    public ModelManager(ConfigManager configManager, TrialData trialData, IConversationMap conversationMap)
    {
        WorldModel = new WorldModel(configManager, trialData, conversationMap);        
    }
}
