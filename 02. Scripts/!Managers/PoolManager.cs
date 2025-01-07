using System.Collections.Generic;
using GamePlay.Factories;
using UnityEngine;

/// <summary>
/// 오브젝트 풀링을 관리하는 클래스.
/// 오브젝트 생성 및 재사용을 통해 성능을 최적화합니다.
/// </summary>
public class PoolManager
{
    ResourceManager _resourceManager; // 리소스 로드 관리
    const string PREFAB_PATH_FORMAT = "Prefabs/{0}"; // 프리팹 경로 포맷
    Dictionary<string, Pool> _poolDictionary = new Dictionary<string, Pool>(); // 각 프리팹 이름별 풀 관리

    /// <summary>
    /// 뷰 팩토리 인스턴스.
    /// </summary>
    public ViewFactory ViewFactory { get; private set; }

    /// <summary>
    /// PoolManager 생성자.
    /// </summary>
    /// <param name="resourceManager">리소스 관리자를 주입받습니다.</param>
    public PoolManager(ResourceManager resourceManager)
    {
        _resourceManager = resourceManager;
        ViewFactory = new ViewFactory(this);
    }

    /// <summary>
    /// 주어진 프리팹 이름과 크기로 풀을 생성합니다.
    /// </summary>
    /// <param name="prefabName">프리팹 이름</param>
    /// <param name="size">초기 풀 크기</param>
    /// <returns>생성된 풀</returns>
    public Pool CreatePool(string prefabName, int size = 1)
    {
        // 프리팹 로드
        GameObject prefab = _resourceManager.LoadResource<GameObject>(string.Format(PREFAB_PATH_FORMAT, prefabName));
        if (prefab == null)
        {
            Debug.LogError($"Resource at path(Prefabs/{prefabName}) could not be found.");
            return null;
        }
        return CreatePool(prefabName, prefab, size);
    }

    /// <summary>
    /// 주어진 프리팹으로 풀을 생성합니다. 
    /// </summary>
    /// <param name="prefabName">프리팹 이름</param>
    /// <param name="prefab">프리팹 객체</param>
    /// <param name="size">초기 풀 크기</param>
    /// <returns>생성된 풀</returns>
    Pool CreatePool(string prefabName, GameObject prefab, int size = 1)
    {
        if (!_poolDictionary.TryGetValue(prefabName, out var pool))
        {
            // 풀을 관리할 부모 객체 생성
            Transform parent = new GameObject($"@Pool_{prefabName}").transform;
            Object.DontDestroyOnLoad(parent);
            pool = new Pool(prefab, parent, size);
            _poolDictionary[prefabName] = pool;
        }
        return pool;
    }

    /// <summary>
    /// 풀에서 객체를 가져옵니다. 풀에 없으면 새로 생성합니다.
    /// </summary>
    /// <param name="prefabName">프리팹 이름</param>
    /// <returns>풀에서 가져온 객체</returns>
    public GameObject GetFromPool(string prefabName)
    {
        if (!_poolDictionary.TryGetValue(prefabName, out var pool))
        {
            pool = CreatePool(prefabName);
        }

        if (pool == null)
        {
            return null;
        }

        return pool.Pop();
    }
}

/// <summary>
/// 오브젝트 풀을 관리하는 클래스.
/// </summary>
public class Pool
{
    private Stack<GameObject> _stackPool; // 비활성화된 객체를 관리하는 스택
    private GameObject _prefab; // 풀링할 프리팹
    private Transform _parent; // 부모 트랜스폼

    /// <summary>
    /// Pool 생성자.
    /// </summary>
    /// <param name="prefab">풀링할 프리팹</param>
    /// <param name="parent">풀의 부모 트랜스폼</param>
    /// <param name="initialSize">초기 풀 크기</param>
    public Pool(GameObject prefab, Transform parent, int initialSize)
    {
        _prefab = prefab;
        _parent = parent;
        _stackPool = new Stack<GameObject>();

        // 초기 크기만큼 풀 채우기
        for (int i = 0; i < initialSize; i++)
        {
            CreatePoolObj();
        }
    }

    /// <summary>
    /// 풀에 새 객체를 추가합니다.
    /// </summary>
    void CreatePoolObj()
    {
        GameObject obj = Object.Instantiate(_prefab);
        obj.transform.SetParent(_parent, false);
        obj.SetActive(false);
        obj.GetOrAddComponent<Poolable>().SetPool(this);
        _stackPool.Push(obj);
    }

    /// <summary>
    /// 풀에서 객체를 가져옵니다. 없으면 새로 생성합니다.
    /// </summary>
    /// <returns>풀에서 가져온 객체</returns>
    public GameObject Pop()
    {
        if (_stackPool.Count > 0)
        {
            GameObject obj = _stackPool.Pop();
            obj.SetActive(true);
            return obj;
        }

        // 풀에 객체가 없으면 새로 생성
        GameObject newObj = Object.Instantiate(_prefab);
        newObj.GetOrAddComponent<Poolable>().SetPool(this);
        return newObj;
    }

    /// <summary>
    /// 객체를 풀로 반환합니다.
    /// </summary>
    /// <param name="obj">반환할 객체</param>
    public void Push(GameObject obj)
    {
        obj.transform.SetParent(_parent, false);
        obj.SetActive(false);
        _stackPool.Push(obj);
    }
}