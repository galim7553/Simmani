using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���ҽ� �ε� �� ���� �������̽�.
/// ���ҽ��� �ε��ϴ� ����� �����մϴ�.
/// </summary>
public interface IResourceMap
{
    /// <summary>
    /// ���ҽ��� �ε��մϴ�.
    /// </summary>
    /// <typeparam name="T">�ε��� ���ҽ��� Ÿ��</typeparam>
    /// <param name="path">���ҽ��� ���</param>
    /// <returns>�ε�� ���ҽ�</returns>
    T LoadResource<T>(string path) where T : UnityEngine.Object;
}

/// <summary>
/// Resources �������� ���ҽ��� �ε��ϰ� ĳ���Ͽ� �����ϴ� Ŭ����.
/// </summary>
public class ResourceManager : IResourceMap
{
    // Ÿ�Ժ��� ���ҽ��� ĳ���ϱ� ���� ��ųʸ�
    Dictionary<Type, Dictionary<string, UnityEngine.Object>> _resourceCache = new Dictionary<Type, Dictionary<string, UnityEngine.Object>>();

    /// <summary>
    /// ���ҽ��� �ε��մϴ�. �̹� ĳ�ÿ� �ִٸ� ĳ�ÿ��� ��ȯ�մϴ�.
    /// </summary>
    /// <typeparam name="T">�ε��� ���ҽ��� Ÿ��</typeparam>
    /// <param name="path">Resources ���� �� ���ҽ��� ���</param>
    /// <returns>�ε�� ���ҽ� ��ü</returns>
    public T LoadResource<T>(string path) where T : UnityEngine.Object
    {
        // Ÿ�Ժ� ĳ�� Ȯ��
        if (!_resourceCache.TryGetValue(typeof(T), out var cache))
        {
            cache = new Dictionary<string, UnityEngine.Object>();
            _resourceCache[typeof(T)] = cache;
        }

        // ��ο� ���� ĳ�� Ȯ��
        if (cache.ContainsKey(path))
        {
            return cache[path] as T;
        }

        // Resources �������� ���ҽ� �ε�
        T resource = Resources.Load<T>(path);
        if (resource == null)
        {
            Debug.LogWarning($"Could not find Resource at path({path})");
        }
        else
        {
            cache[path] = resource; // ĳ�ÿ� �߰�
        }
        return resource;
    }

    /// <summary>
    /// Ư�� ���ҽ��� ��ε��մϴ�.
    /// </summary>
    /// <typeparam name="T">��ε��� ���ҽ��� Ÿ��</typeparam>
    /// <param name="path">Resources ���� �� ���ҽ��� ���</param>
    public void UnloadResource<T>(string path) where T : UnityEngine.Object
    {
        // Ÿ�Ժ� ĳ�� Ȯ��
        if (_resourceCache.TryGetValue(typeof(T), out var cache))
        {
            if (cache.ContainsKey(path))
            {
                Resources.UnloadAsset(cache[path]); // ���ҽ� ��ε�
                cache.Remove(path); // ĳ�ÿ��� ����
            }
            else
            {
                Debug.LogWarning($"No cached resource found at path({path}) to unload.");
            }
        }
    }

    /// <summary>
    /// Ư�� Ÿ���� ��� ĳ�õ� ���ҽ��� ��ε��մϴ�.
    /// </summary>
    /// <typeparam name="T">��ε��� ���ҽ��� Ÿ��</typeparam>
    public void UnloadAllResources<T>() where T : UnityEngine.Object
    {
        // Ÿ�Ժ� ĳ�� Ȯ��
        if (_resourceCache.TryGetValue(typeof(T), out var cache))
        {
            foreach (var resource in cache.Values)
            {
                Resources.UnloadAsset(resource); // ���ҽ� ��ε�
            }
            cache.Clear(); // ĳ�� ����
        }
    }
}