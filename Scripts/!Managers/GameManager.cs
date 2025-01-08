using GamePlay.Presenters;
using GamePlay.Scene;

/// <summary>
/// ������ ���� ���¿� �ֿ� �����ڸ� �ʱ�ȭ�ϰ� �����ϴ� �̱��� Ŭ����.
/// </summary>
public class GameManager : GSingleton<GameManager>
{
    // ���� �� �ֿ� �����ڵ�
    public ResourceManager ResourceManager { get; private set; }
    public PoolManager PoolManager { get; private set; }
    public LanguageManager LanguageManager { get; private set; }
    public SoundManager SoundManager { get; private set; }
    public ModelManager ModelManager { get; private set; }
    public DataManager DataManager { get; private set; }
    public ConfigManager ConfigManager { get; private set; }

    // �� �δ� ����
    public SceneLoader SceneLoader { get; private set; }

    /// <summary>
    /// GameManager�� Awake �ܰ迡�� �ֿ� �����ڸ� �ʱ�ȭ�մϴ�.
    /// </summary>
    protected override void Awake()
    {
        base.Awake();
        InitializeManagers(); // �ֿ� ������ �ʱ�ȭ
    }

    /// <summary>
    /// ������ �ֿ� �����ڸ� �ʱ�ȭ�ϰ� �����մϴ�.
    /// </summary>
    private void InitializeManagers()
    {
        // ResourceManager �ʱ�ȭ
        ResourceManager = new ResourceManager();

        // ��Ÿ �����ڸ� �ʱ�ȭ�ϰ� �������� ����
        PoolManager = new PoolManager(ResourceManager);
        LanguageManager = new LanguageManager(ResourceManager);
        SoundManager = new SoundManager(ResourceManager);
        DataManager = new DataManager();
        ConfigManager = new ConfigManager(ResourceManager);
        ModelManager = new ModelManager(ConfigManager, DataManager.TrialData, LanguageManager);

        // Presenter�� ���ҽ� �ʱ�ȭ
        ResourceDependentPresenterBase.Initialize(LanguageManager, ResourceManager);

        // SceneLoader �ʱ�ȭ
        SceneLoader = PoolManager.GetFromPool("SceneLoader").GetComponent<SceneLoader>();
        SceneLoader.transform.SetParent(transform); // SceneLoader�� GameManager�� �ڽ����� ����
        SceneLoader.Initialize(ModelManager.WorldModel); // SceneLoader�� ���� ���� �����Ͽ� �ʱ�ȭ
    }
}