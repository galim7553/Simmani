using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IResourceMap
{
    T LoadResource<T>(string path) where T : UnityEngine.Object;
}

public class ResourceManager : IResourceMap
{
    Dictionary<Type, Dictionary<string, UnityEngine.Object>> _resourceCache = new Dictionary<Type, Dictionary<string, UnityEngine.Object>>();

    /// <summary>
    /// ���ҽ��� �ε��մϴ�. ĳ�õ� ���ҽ��� ������ ĳ�ÿ��� ��ȯ�մϴ�.
    /// </summary>
    /// <typeparam name="T">�ε��� ���ҽ��� Ÿ��</typeparam>
    /// <param name="path">Resources ���� �� ���ҽ��� ���</param>
    /// <returns>�ε�� ���ҽ�</returns>
    public T LoadResource<T>(string path) where T : UnityEngine.Object
    {
        Dictionary<string, UnityEngine.Object> cache;
        if(_resourceCache.TryGetValue(typeof(T), out cache) == false)
        {
            cache = new Dictionary<string, UnityEngine.Object>();
            _resourceCache[typeof(T)] = cache;
        }


        if (cache.ContainsKey(path) == true)
            return cache[path] as T;

        T resource = Resources.Load<T>(path);
        if (resource == null)
            Debug.LogWarning($"Could not find Resource at path({path})");
        else
            cache[path] = resource;
        return resource;
    }

    /// <summary>
    /// T Ÿ���� Ư�� ���ҽ��� ��ε��մϴ�.
    /// </summary>
    /// <param name="path">Resources ���� �� ���ҽ��� ���</param>
    public void UnloadResource<T>(string path)
    {
        Dictionary<string, UnityEngine.Object> cache;
        if (_resourceCache.TryGetValue(typeof(T), out cache) == true)
        {
            if (cache.ContainsKey(path) == true)
            {
                Resources.UnloadAsset(cache[path]);
                cache.Remove(path);
            }
            else
                Debug.LogWarning($"No cached resource found at path({path}) to unload.");
        }
    }

    /// <summary>
    /// T Ÿ���� ��� ĳ�õ� ���ҽ��� ��ε��մϴ�.
    /// </summary>
    public void UnloadAllResources<T>()
    {
        Dictionary<string, UnityEngine.Object> cache;
        if (_resourceCache.TryGetValue(typeof(T), out cache) == true)
        {
            foreach (var res in cache.Values)
                Resources.UnloadAsset(res);
            cache.Clear();
        }
    }
}