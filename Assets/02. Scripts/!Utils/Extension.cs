using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extension
{

    /// <summary>
    /// Ȯ���� ���� ���õ� Index�� ��ȯ�մϴ�.
    /// </summary>
    /// <param name="probs"></param>
    /// <returns></returns>
    public static int Choose(this IReadOnlyList<float> probs)
    {
        return Util.Ran.Choose(probs);
    }

    public static T Choose<T>(this IReadOnlyList<T> list) where T : class
    {
        return Util.Ran.Choose<T>(list);
    }

    /// <summary>
    /// ����Ʈ�� ������ ������ �����մϴ�.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="list"></param>
    public static void Shuffle<T>(this IList<T> list)
    {
        Util.Ran.Shuffle(list);
    }

    /// <summary>
    /// �־��� GameObject�� �ڽ� �߿��� Ư�� �̸��� ���� T Ÿ���� ������Ʈ�� ã���ϴ�.
    /// �ڽ� ���鸸 Ž���ϰų�, ��������� ��� ���� �ڽı��� Ž���� �� �ֽ��ϴ�.
    /// </summary>
    /// <typeparam name="T">ã������ ������Ʈ�� Ÿ��</typeparam>
    /// <param name="name">ã������ �ڽ��� �̸� (null�� ��� �̸��� ������� ã��)</param>
    /// <param name="recursive">true�� ��� ��������� ��� ���� �ڽı��� Ž��, false�� ��� ���� �ڽĵ鸸 Ž��</param>
    /// <returns>ã�� T Ÿ���� ������Ʈ. ã�� ���ϸ� null�� ��ȯ</returns>
    public static T FindChild<T>(this GameObject go, string name = null, bool recursive = false) where T : Object
    {
        return Util.FindChild<T>(go, name, recursive);
    }

    /// <summary>
    /// �־��� GameObject�� �ڽ� GameObject�� �̸����� ã���ϴ�.
    /// �ڽ� ���鸸 Ž���ϰų�, ��������� ��� ���� �ڽı��� Ž���� �� �ֽ��ϴ�.
    /// </summary>
    /// <param name="name">ã������ �ڽ� GameObject�� �̸� (null�� ��� �̸��� ������� Ž��)</param>
    /// <param name="recursive">true�� ��� ��������� ��� ���� �ڽı��� Ž��, false�� ��� ���� �ڽĵ鸸 Ž��</param>
    /// <returns>ã�� GameObject. ã�� ���ϸ� null�� ��ȯ</returns>
    /// <returns></returns>
    public static GameObject FindChild(this GameObject go, string name = null, bool recursive = false)
    {
        return Util.FindChild(go, name, recursive);
    }

    /// <summary>
    /// ���� ������Ʈ�� T ������Ʈ�� �߰��ϰų� ã���ϴ�.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="go"></param>
    /// <returns></returns>
    public static T GetOrAddComponent<T>(this GameObject go) where T : Component
    {
        return Util.GetOrAddComponent<T>(go);
    }
    /// <summary>
    /// ������Ʈ�� T ������Ʈ�� �߰��ϰų� ã���ϴ�.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="target"></param>
    /// <returns></returns>
    public static T GetOrAddComponent<T>(this Component target) where T : Component
    {
        return Util.GetOrAddComponent<T>(target);
    }

    public static void DestroyOrReturnToPool(this GameObject go)
    {
        Util.DestroyOrReturnToPool(go);
    }

    /// <summary>
    /// Ư�� ���� ��ǥ���� Terrain�� ��� ���͸� �����ɴϴ�.
    /// </summary>
    /// <param name="terrain">��� ���͸� ������ Terrain</param>
    /// <param name="worldPosition">��� ���͸� ������ ���� ��ǥ</param>
    /// <returns>������ ��ġ�� ��� ����</returns>
    public static Vector3 GetNormalAtWorldPosition(this Terrain terrain, Vector3 worldPosition)
    {
        if (terrain == null)
        {
            Debug.LogError("Terrain is null. Please provide a valid Terrain.");
            return Vector3.up; // �⺻������ ���� ���� ���� ��ȯ
        }

        TerrainData terrainData = terrain.terrainData;
        Vector3 terrainPosition = terrain.transform.position;
        Vector3 terrainSize = terrainData.size;

        // ���� ��ǥ�� Terrain�� ��� ��ǥ�� ��ȯ
        float relativeX = (worldPosition.x - terrainPosition.x) / terrainSize.x;
        float relativeZ = (worldPosition.z - terrainPosition.z) / terrainSize.z;

        // ��� ��ǥ�� 0~1 ���� ���� �ִ��� Ȯ��
        if (relativeX < 0 || relativeX > 1 || relativeZ < 0 || relativeZ > 1)
        {
            Debug.LogWarning("World position is out of terrain bounds.");
            return Vector3.up; // ������ ��� ��� �⺻������ ���� ���� ���� ��ȯ
        }

        // ��� ��ǥ�� ����Ͽ� ��� ���� ��������
        Vector3 normal = terrainData.GetInterpolatedNormal(relativeX, relativeZ);
        return normal;
    }

}

