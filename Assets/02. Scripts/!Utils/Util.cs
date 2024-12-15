using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class Util
{
    // 랜덤 요소
    public static class Ran
    {

        /// <summary>
        /// 확률에 따라 선택된 Index를 반환합니다.
        /// </summary>
        /// <param name="probs"></param>
        /// <returns></returns>
        public static int Choose(IReadOnlyList<float> probs)
        {
            float total = 0;

            foreach (float prob in probs)
            {
                if (prob > 0f)
                    total += prob;
            }

            float ranVal = Random.value * total;

            for (int i = 0; i < probs.Count; i++)
            {
                if (probs[i] <= 0f) continue;

                if (ranVal <= probs[i])
                    return i;
                else
                    ranVal -= probs[i];
            }

            return 0;
        }
        public static T Choose<T>(IReadOnlyList<T> list)
        {
            if (list == null || list.Count == 0)
                return default(T);
            int index = Random.Range(0, list.Count);
            return list[index];
        }

        /// <summary>
        /// List를 랜덤한 순서로 셔플합니다.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        public static void Shuffle<T>(IList<T> list)
        {
            int n = list.Count;
            for (int i = 0; i < n; i++)
            {
                int k = Random.Range(i, n);
                T temp = list[k];
                list[k] = list[i];
                list[i] = temp;
            }
        }
    }

    /// <summary>
    /// 0.01f
    /// </summary>
    public const float EPSILON = 0.01f;

    /// <summary>
    /// 주어진 GameObject의 자식 중에서 특정 이름을 가진 T 타입의 컴포넌트를 찾습니다.
    /// 자식 노드들만 탐색하거나, 재귀적으로 모든 하위 자식까지 탐색할 수 있습니다.
    /// </summary>
    /// <typeparam name="T">찾으려는 컴포넌트의 타입</typeparam>
    /// <param name="target">탐색할 부모 GameObject</param>
    /// <param name="name">찾으려는 자식의 이름 (null일 경우 이름과 상관없이 찾음)</param>
    /// <param name="recursive">true일 경우 재귀적으로 모든 하위 자식까지 탐색, false일 경우 직계 자식들만 탐색</param>
    /// <returns>찾은 T 타입의 컴포넌트. 찾지 못하면 null을 반환</returns>
    public static T FindChild<T>(GameObject target, string name = null, bool recursive = false) where T : UnityEngine.Object
    {
        if (target == null)
        {
            Debug.LogError($"Could not find Component of type ({typeof(T).Name}) in null target");
            return null;
        }

        if (!recursive)
        {
            // 자식들만 탐색 (최상위 레벨)
            for (int i = 0; i < target.transform.childCount; i++)
            {
                Transform transform = target.transform.GetChild(i);

                // 이름이 없는 경우나, 이름이 일치하는 경우에만 진행
                if (string.IsNullOrEmpty(name) || transform.name == name)
                {
                    T component = transform.GetComponent<T>();
                    if (component != null)
                        return component;
                }
            }
        }
        else
        {
            // 재귀적으로 모든 자식들 탐색
            foreach (T child in target.GetComponentsInChildren<T>(true))
            {
                if (string.IsNullOrEmpty(name) || child.name == name)
                    return child; // 처음 찾은 자식을 반환
            }
        }

        // 조건에 맞는 컴포넌트가 없으면 null 반환
        if (!string.IsNullOrEmpty(name))
            Debug.LogError($"Could not find Component of type ({typeof(T).Name}) with name '{name}' in {target.name}");
        else
            Debug.LogError($"Could not find Component of type ({typeof(T).Name}) in {target.name}");
        return null;
    }

    /// <summary>
    /// 주어진 GameObject의 자식 GameObject를 이름으로 찾습니다.
    /// 자식 노드들만 탐색하거나, 재귀적으로 모든 하위 자식까지 탐색할 수 있습니다.
    /// </summary>
    /// <param name="target">탐색할 부모 GameObject</param>
    /// <param name="name">찾으려는 자식 GameObject의 이름 (null일 경우 이름과 상관없이 탐색)</param>
    /// <param name="recursive">true일 경우 재귀적으로 모든 하위 자식까지 탐색, false일 경우 직계 자식들만 탐색</param>
    /// <returns>찾은 GameObject. 찾지 못하면 null을 반환</returns>
    public static GameObject FindChild(GameObject target, string name = null, bool recursive = false)
    {
        Transform transform = FindChild<Transform>(target, name, recursive);
        if (transform == null)
        {
            Debug.LogError($"Could not find GameObject name({name}) in {target.name}");
            return null;
        }
        return transform.gameObject;
    }

    /// <summary>
    /// 게임 오브젝트에서 T 타입의 컴포넌트를 찾고, 없으면 새로 추가합니다.
    /// </summary>
    /// <typeparam name="T">찾거나 추가할 컴포넌트의 타입</typeparam>
    /// <param name="go">대상 게임 오브젝트</param>
    /// <returns>찾거나 새로 추가한 T 타입의 컴포넌트</returns>
    public static T GetOrAddComponent<T>(GameObject go) where T : Component
    {
        T component = go.GetComponent<T>();
        if (component == null)
            component = go.AddComponent<T>();
        return component;
    }
    /// <summary>
    /// 컴포넌트에서 T 타입의 컴포넌트를 찾고, 없으면 새로 추가합니다.
    /// </summary>
    /// <typeparam name="T">찾거나 추가할 컴포넌트의 타입</typeparam>
    /// <param name="target">대상 컴포넌트</param>
    /// <returns>찾거나 새로 추가한 T 타입의 컴포넌트</returns>
    public static T GetOrAddComponent<T>(Component target) where T : Component
    {
        T component = target.GetComponent<T>();
        if (component == null)
            component = target.gameObject.AddComponent<T>();
        return component;
    }


    public static void DestroyOrReturnToPool(GameObject go)
    {
        Poolable poolObj = go.GetComponent<Poolable>();
        if (poolObj != null)
            poolObj.ReturnToPool();
        else
            Object.Destroy(go);
    }
}
