using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 리소스 로드 및 관리 인터페이스.
/// 리소스를 로드하는 기능을 제공합니다.
/// </summary>
public interface IResourceMap
{
    /// <summary>
    /// 리소스를 로드합니다.
    /// </summary>
    /// <typeparam name="T">로드할 리소스의 타입</typeparam>
    /// <param name="path">리소스의 경로</param>
    /// <returns>로드된 리소스</returns>
    T LoadResource<T>(string path) where T : UnityEngine.Object;
}

/// <summary>
/// Resources 폴더에서 리소스를 로드하고 캐싱하여 관리하는 클래스.
/// </summary>
public class ResourceManager : IResourceMap
{
    // 타입별로 리소스를 캐싱하기 위한 딕셔너리
    Dictionary<Type, Dictionary<string, UnityEngine.Object>> _resourceCache = new Dictionary<Type, Dictionary<string, UnityEngine.Object>>();

    /// <summary>
    /// 리소스를 로드합니다. 이미 캐시에 있다면 캐시에서 반환합니다.
    /// </summary>
    /// <typeparam name="T">로드할 리소스의 타입</typeparam>
    /// <param name="path">Resources 폴더 내 리소스의 경로</param>
    /// <returns>로드된 리소스 객체</returns>
    public T LoadResource<T>(string path) where T : UnityEngine.Object
    {
        // 타입별 캐시 확인
        if (!_resourceCache.TryGetValue(typeof(T), out var cache))
        {
            cache = new Dictionary<string, UnityEngine.Object>();
            _resourceCache[typeof(T)] = cache;
        }

        // 경로에 따른 캐시 확인
        if (cache.ContainsKey(path))
        {
            return cache[path] as T;
        }

        // Resources 폴더에서 리소스 로드
        T resource = Resources.Load<T>(path);
        if (resource == null)
        {
            Debug.LogWarning($"Could not find Resource at path({path})");
        }
        else
        {
            cache[path] = resource; // 캐시에 추가
        }
        return resource;
    }

    /// <summary>
    /// 특정 리소스를 언로드합니다.
    /// </summary>
    /// <typeparam name="T">언로드할 리소스의 타입</typeparam>
    /// <param name="path">Resources 폴더 내 리소스의 경로</param>
    public void UnloadResource<T>(string path) where T : UnityEngine.Object
    {
        // 타입별 캐시 확인
        if (_resourceCache.TryGetValue(typeof(T), out var cache))
        {
            if (cache.ContainsKey(path))
            {
                Resources.UnloadAsset(cache[path]); // 리소스 언로드
                cache.Remove(path); // 캐시에서 제거
            }
            else
            {
                Debug.LogWarning($"No cached resource found at path({path}) to unload.");
            }
        }
    }

    /// <summary>
    /// 특정 타입의 모든 캐시된 리소스를 언로드합니다.
    /// </summary>
    /// <typeparam name="T">언로드할 리소스의 타입</typeparam>
    public void UnloadAllResources<T>() where T : UnityEngine.Object
    {
        // 타입별 캐시 확인
        if (_resourceCache.TryGetValue(typeof(T), out var cache))
        {
            foreach (var resource in cache.Values)
            {
                Resources.UnloadAsset(resource); // 리소스 언로드
            }
            cache.Clear(); // 캐시 비우기
        }
    }
}