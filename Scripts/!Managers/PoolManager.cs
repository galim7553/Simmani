using System.Collections.Generic;
using GamePlay.Factories;
using UnityEngine;

/// <summary>
/// ������Ʈ Ǯ���� �����ϴ� Ŭ����.
/// ������Ʈ ���� �� ������ ���� ������ ����ȭ�մϴ�.
/// </summary>
public class PoolManager
{
    ResourceManager _resourceManager; // ���ҽ� �ε� ����
    const string PREFAB_PATH_FORMAT = "Prefabs/{0}"; // ������ ��� ����
    Dictionary<string, Pool> _poolDictionary = new Dictionary<string, Pool>(); // �� ������ �̸��� Ǯ ����

    /// <summary>
    /// �� ���丮 �ν��Ͻ�.
    /// </summary>
    public ViewFactory ViewFactory { get; private set; }

    /// <summary>
    /// PoolManager ������.
    /// </summary>
    /// <param name="resourceManager">���ҽ� �����ڸ� ���Թ޽��ϴ�.</param>
    public PoolManager(ResourceManager resourceManager)
    {
        _resourceManager = resourceManager;
        ViewFactory = new ViewFactory(this);
    }

    /// <summary>
    /// �־��� ������ �̸��� ũ��� Ǯ�� �����մϴ�.
    /// </summary>
    /// <param name="prefabName">������ �̸�</param>
    /// <param name="size">�ʱ� Ǯ ũ��</param>
    /// <returns>������ Ǯ</returns>
    public Pool CreatePool(string prefabName, int size = 1)
    {
        // ������ �ε�
        GameObject prefab = _resourceManager.LoadResource<GameObject>(string.Format(PREFAB_PATH_FORMAT, prefabName));
        if (prefab == null)
        {
            Debug.LogError($"Resource at path(Prefabs/{prefabName}) could not be found.");
            return null;
        }
        return CreatePool(prefabName, prefab, size);
    }

    /// <summary>
    /// �־��� ���������� Ǯ�� �����մϴ�. 
    /// </summary>
    /// <param name="prefabName">������ �̸�</param>
    /// <param name="prefab">������ ��ü</param>
    /// <param name="size">�ʱ� Ǯ ũ��</param>
    /// <returns>������ Ǯ</returns>
    Pool CreatePool(string prefabName, GameObject prefab, int size = 1)
    {
        if (!_poolDictionary.TryGetValue(prefabName, out var pool))
        {
            // Ǯ�� ������ �θ� ��ü ����
            Transform parent = new GameObject($"@Pool_{prefabName}").transform;
            Object.DontDestroyOnLoad(parent);
            pool = new Pool(prefab, parent, size);
            _poolDictionary[prefabName] = pool;
        }
        return pool;
    }

    /// <summary>
    /// Ǯ���� ��ü�� �����ɴϴ�. Ǯ�� ������ ���� �����մϴ�.
    /// </summary>
    /// <param name="prefabName">������ �̸�</param>
    /// <returns>Ǯ���� ������ ��ü</returns>
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
/// ������Ʈ Ǯ�� �����ϴ� Ŭ����.
/// </summary>
public class Pool
{
    private Stack<GameObject> _stackPool; // ��Ȱ��ȭ�� ��ü�� �����ϴ� ����
    private GameObject _prefab; // Ǯ���� ������
    private Transform _parent; // �θ� Ʈ������

    /// <summary>
    /// Pool ������.
    /// </summary>
    /// <param name="prefab">Ǯ���� ������</param>
    /// <param name="parent">Ǯ�� �θ� Ʈ������</param>
    /// <param name="initialSize">�ʱ� Ǯ ũ��</param>
    public Pool(GameObject prefab, Transform parent, int initialSize)
    {
        _prefab = prefab;
        _parent = parent;
        _stackPool = new Stack<GameObject>();

        // �ʱ� ũ�⸸ŭ Ǯ ä���
        for (int i = 0; i < initialSize; i++)
        {
            CreatePoolObj();
        }
    }

    /// <summary>
    /// Ǯ�� �� ��ü�� �߰��մϴ�.
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
    /// Ǯ���� ��ü�� �����ɴϴ�. ������ ���� �����մϴ�.
    /// </summary>
    /// <returns>Ǯ���� ������ ��ü</returns>
    public GameObject Pop()
    {
        if (_stackPool.Count > 0)
        {
            GameObject obj = _stackPool.Pop();
            obj.SetActive(true);
            return obj;
        }

        // Ǯ�� ��ü�� ������ ���� ����
        GameObject newObj = Object.Instantiate(_prefab);
        newObj.GetOrAddComponent<Poolable>().SetPool(this);
        return newObj;
    }

    /// <summary>
    /// ��ü�� Ǯ�� ��ȯ�մϴ�.
    /// </summary>
    /// <param name="obj">��ȯ�� ��ü</param>
    public void Push(GameObject obj)
    {
        obj.transform.SetParent(_parent, false);
        obj.SetActive(false);
        _stackPool.Push(obj);
    }
}