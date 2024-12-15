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
    /// 리소스를 로드합니다. 캐시된 리소스가 있으면 캐시에서 반환합니다.
    /// </summary>
    /// <typeparam name="T">로드할 리소스의 타입</typeparam>
    /// <param name="path">Resources 폴더 내 리소스의 경로</param>
    /// <returns>로드된 리소스</returns>
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
    /// T 타입의 특정 리소스를 언로드합니다.
    /// </summary>
    /// <param name="path">Resources 폴더 내 리소스의 경로</param>
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
    /// T 타입의 모든 캐시된 리소스를 언로드합니다.
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