using GamePlay.Presenters;
using GamePlay.Scene;

/// <summary>
/// 게임의 전역 상태와 주요 관리자를 초기화하고 관리하는 싱글톤 클래스.
/// </summary>
public class GameManager : GSingleton<GameManager>
{
    // 게임 내 주요 관리자들
    public ResourceManager ResourceManager { get; private set; }
    public PoolManager PoolManager { get; private set; }
    public LanguageManager LanguageManager { get; private set; }
    public SoundManager SoundManager { get; private set; }
    public ModelManager ModelManager { get; private set; }
    public DataManager DataManager { get; private set; }
    public ConfigManager ConfigManager { get; private set; }

    // 씬 로더 관리
    public SceneLoader SceneLoader { get; private set; }

    /// <summary>
    /// GameManager의 Awake 단계에서 주요 관리자를 초기화합니다.
    /// </summary>
    protected override void Awake()
    {
        base.Awake();
        InitializeManagers(); // 주요 관리자 초기화
    }

    /// <summary>
    /// 게임의 주요 관리자를 초기화하고 연결합니다.
    /// </summary>
    private void InitializeManagers()
    {
        // ResourceManager 초기화
        ResourceManager = new ResourceManager();

        // 기타 관리자를 초기화하고 의존성을 연결
        PoolManager = new PoolManager(ResourceManager);
        LanguageManager = new LanguageManager(ResourceManager);
        SoundManager = new SoundManager(ResourceManager);
        DataManager = new DataManager();
        ConfigManager = new ConfigManager(ResourceManager);
        ModelManager = new ModelManager(ConfigManager, DataManager.TrialData, LanguageManager);

        // Presenter의 리소스 초기화
        ResourceDependentPresenterBase.Initialize(LanguageManager, ResourceManager);

        // SceneLoader 초기화
        SceneLoader = PoolManager.GetFromPool("SceneLoader").GetComponent<SceneLoader>();
        SceneLoader.transform.SetParent(transform); // SceneLoader를 GameManager의 자식으로 설정
        SceneLoader.Initialize(ModelManager.WorldModel); // SceneLoader에 월드 모델을 전달하여 초기화
    }
}