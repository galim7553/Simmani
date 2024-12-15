using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class Util
{
    // ���� ���
    public static class Ran
    {

        /// <summary>
        /// Ȯ���� ���� ���õ� Index�� ��ȯ�մϴ�.
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
        /// List�� ������ ������ �����մϴ�.
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
    /// �־��� GameObject�� �ڽ� �߿��� Ư�� �̸��� ���� T Ÿ���� ������Ʈ�� ã���ϴ�.
    /// �ڽ� ���鸸 Ž���ϰų�, ��������� ��� ���� �ڽı��� Ž���� �� �ֽ��ϴ�.
    /// </summary>
    /// <typeparam name="T">ã������ ������Ʈ�� Ÿ��</typeparam>
    /// <param name="target">Ž���� �θ� GameObject</param>
    /// <param name="name">ã������ �ڽ��� �̸� (null�� ��� �̸��� ������� ã��)</param>
    /// <param name="recursive">true�� ��� ��������� ��� ���� �ڽı��� Ž��, false�� ��� ���� �ڽĵ鸸 Ž��</param>
    /// <returns>ã�� T Ÿ���� ������Ʈ. ã�� ���ϸ� null�� ��ȯ</returns>
    public static T FindChild<T>(GameObject target, string name = null, bool recursive = false) where T : UnityEngine.Object
    {
        if (target == null)
        {
            Debug.LogError($"Could not find Component of type ({typeof(T).Name}) in null target");
            return null;
        }

        if (!recursive)
        {
            // �ڽĵ鸸 Ž�� (�ֻ��� ����)
            for (int i = 0; i < target.transform.childCount; i++)
            {
                Transform transform = target.transform.GetChild(i);

                // �̸��� ���� ��쳪, �̸��� ��ġ�ϴ� ��쿡�� ����
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
            // ��������� ��� �ڽĵ� Ž��
            foreach (T child in target.GetComponentsInChildren<T>(true))
            {
                if (string.IsNullOrEmpty(name) || child.name == name)
                    return child; // ó�� ã�� �ڽ��� ��ȯ
            }
        }

        // ���ǿ� �´� ������Ʈ�� ������ null ��ȯ
        if (!string.IsNullOrEmpty(name))
            Debug.LogError($"Could not find Component of type ({typeof(T).Name}) with name '{name}' in {target.name}");
        else
            Debug.LogError($"Could not find Component of type ({typeof(T).Name}) in {target.name}");
        return null;
    }

    /// <summary>
    /// �־��� GameObject�� �ڽ� GameObject�� �̸����� ã���ϴ�.
    /// �ڽ� ���鸸 Ž���ϰų�, ��������� ��� ���� �ڽı��� Ž���� �� �ֽ��ϴ�.
    /// </summary>
    /// <param name="target">Ž���� �θ� GameObject</param>
    /// <param name="name">ã������ �ڽ� GameObject�� �̸� (null�� ��� �̸��� ������� Ž��)</param>
    /// <param name="recursive">true�� ��� ��������� ��� ���� �ڽı��� Ž��, false�� ��� ���� �ڽĵ鸸 Ž��</param>
    /// <returns>ã�� GameObject. ã�� ���ϸ� null�� ��ȯ</returns>
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
    /// ���� ������Ʈ���� T Ÿ���� ������Ʈ�� ã��, ������ ���� �߰��մϴ�.
    /// </summary>
    /// <typeparam name="T">ã�ų� �߰��� ������Ʈ�� Ÿ��</typeparam>
    /// <param name="go">��� ���� ������Ʈ</param>
    /// <returns>ã�ų� ���� �߰��� T Ÿ���� ������Ʈ</returns>
    public static T GetOrAddComponent<T>(GameObject go) where T : Component
    {
        T component = go.GetComponent<T>();
        if (component == null)
            component = go.AddComponent<T>();
        return component;
    }
    /// <summary>
    /// ������Ʈ���� T Ÿ���� ������Ʈ�� ã��, ������ ���� �߰��մϴ�.
    /// </summary>
    /// <typeparam name="T">ã�ų� �߰��� ������Ʈ�� Ÿ��</typeparam>
    /// <param name="target">��� ������Ʈ</param>
    /// <returns>ã�ų� ���� �߰��� T Ÿ���� ������Ʈ</returns>
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
