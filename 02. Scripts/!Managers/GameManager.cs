using GamePlay.Presenters;
using GamePlay.Scene;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : GSingleton<GameManager>
{

    public ResourceManager ResourceManager { get; private set; } 
    public PoolManager PoolManager { get; private set; }
    public LanguageManager LanguageManager { get; private set; }
    public SoundManager SoundManager { get; private set; }
    public ModelManager ModelManager { get; private set; }
    public DataManager DataManager { get; private set; }
    public ConfigManager ConfigManager { get; private set; }
    

    public SceneLoader SceneLoader { get; private set; }

    protected override void Awake()
    {
        base.Awake();

        InitializeManagers();
    }

    private void InitializeManagers()
    {
        ResourceManager = new ResourceManager();
        PoolManager = new PoolManager(ResourceManager);
        LanguageManager = new LanguageManager(ResourceManager);
        SoundManager = new SoundManager(ResourceManager);
        DataManager = new DataManager();
        ConfigManager = new ConfigManager(ResourceManager);
        ModelManager = new ModelManager(ConfigManager, DataManager.TrialData, LanguageManager);
        

        ResourceDependentPresenterBase.Initialize(LanguageManager, ResourceManager);

        SceneLoader = PoolManager.GetFromPool("SceneLoader").GetComponent<SceneLoader>();
        SceneLoader.transform.SetParent(transform);
        SceneLoader.Initialize(ModelManager.WorldModel);
    }
}
