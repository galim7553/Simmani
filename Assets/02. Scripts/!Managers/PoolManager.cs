using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using GamePlay.Factories;
using UnityEngine;

public class PoolManager
{
    ResourceManager _resourceManager;
    const string PREFAB_PATH_FORMAT = "Prefabs/{0}";
    Dictionary<string, Pool> _poolDictionary = new Dictionary<string, Pool>();

    public ViewFactory ViewFactory { get; private set; }

    public PoolManager(ResourceManager resourceManager)
    {
        _resourceManager = resourceManager;
        ViewFactory = new ViewFactory(this);
    }

    public Pool CreatePool(string prefabName, int size = 1)
    {
        GameObject prefab = _resourceManager.LoadResource<GameObject>(string.Format(PREFAB_PATH_FORMAT, prefabName));
        if(prefab == null)
        {
            Debug.LogError($"Resource at path(Prefabs/{prefabName}) could not be found.");
            return null;
        }
        return CreatePool(prefabName, prefab, size);
    }

    Pool CreatePool(string prefabName, GameObject prefab, int size = 1)
    {
        Pool pool;
        if(_poolDictionary.TryGetValue(prefabName, out pool) == false)
        {
            Transform parent = new GameObject($"@Pool_{prefabName}").transform;
            Object.DontDestroyOnLoad(parent);
            pool = new Pool(prefab, parent, size);
            _poolDictionary[prefabName] = pool;
        }
        return pool;
    }

    public GameObject GetFromPool(string prefabName)
    {
        Pool pool;
        if (_poolDictionary.TryGetValue(prefabName, out pool) == false)
            pool = CreatePool(prefabName);

        if (pool == null)
            return null;

        return pool.Pop();
    }
}

public class Pool
{
    private Stack<GameObject> _stackPool;
    private GameObject _prefab;
    private Transform _parent;

    public Pool(GameObject prefab, Transform parent, int initialSize)
    {
        _prefab = prefab;
        _parent = parent;
        _stackPool = new Stack<GameObject>();

        for (int i = 0; i < initialSize; i++)
            CreatePoolObj();
    }

    void CreatePoolObj()
    {
        GameObject obj = Object.Instantiate(_prefab);
        obj.transform.SetParent(_parent, false);
        obj.SetActive(false);
        obj.GetOrAddComponent<Poolable>().SetPool(this);
        _stackPool.Push(obj);
    }

    public GameObject Pop()
    {
        if(_stackPool.Count > 0)
        {
            GameObject obj = _stackPool.Pop();
            obj.SetActive(true);
            return obj;
        }

        GameObject newObj = Object.Instantiate(_prefab);
        newObj.GetOrAddComponent<Poolable>().SetPool(this);
        return newObj;
    }

    public void Push(GameObject obj)
    {
        obj.transform.SetParent(_parent, false);
        obj.SetActive(false);
        _stackPool.Push(obj);
    }
}