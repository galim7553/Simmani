using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extension
{

    /// <summary>
    /// 확률에 따라 선택된 Index를 반환합니다.
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
    /// 리스트를 랜덤한 순서로 셔플합니다.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="list"></param>
    public static void Shuffle<T>(this IList<T> list)
    {
        Util.Ran.Shuffle(list);
    }

    /// <summary>
    /// 주어진 GameObject의 자식 중에서 특정 이름을 가진 T 타입의 컴포넌트를 찾습니다.
    /// 자식 노드들만 탐색하거나, 재귀적으로 모든 하위 자식까지 탐색할 수 있습니다.
    /// </summary>
    /// <typeparam name="T">찾으려는 컴포넌트의 타입</typeparam>
    /// <param name="name">찾으려는 자식의 이름 (null일 경우 이름과 상관없이 찾음)</param>
    /// <param name="recursive">true일 경우 재귀적으로 모든 하위 자식까지 탐색, false일 경우 직계 자식들만 탐색</param>
    /// <returns>찾은 T 타입의 컴포넌트. 찾지 못하면 null을 반환</returns>
    public static T FindChild<T>(this GameObject go, string name = null, bool recursive = false) where T : Object
    {
        return Util.FindChild<T>(go, name, recursive);
    }

    /// <summary>
    /// 주어진 GameObject의 자식 GameObject를 이름으로 찾습니다.
    /// 자식 노드들만 탐색하거나, 재귀적으로 모든 하위 자식까지 탐색할 수 있습니다.
    /// </summary>
    /// <param name="name">찾으려는 자식 GameObject의 이름 (null일 경우 이름과 상관없이 탐색)</param>
    /// <param name="recursive">true일 경우 재귀적으로 모든 하위 자식까지 탐색, false일 경우 직계 자식들만 탐색</param>
    /// <returns>찾은 GameObject. 찾지 못하면 null을 반환</returns>
    /// <returns></returns>
    public static GameObject FindChild(this GameObject go, string name = null, bool recursive = false)
    {
        return Util.FindChild(go, name, recursive);
    }

    /// <summary>
    /// 게임 오브젝트에 T 컴포넌트를 추가하거나 찾습니다.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="go"></param>
    /// <returns></returns>
    public static T GetOrAddComponent<T>(this GameObject go) where T : Component
    {
        return Util.GetOrAddComponent<T>(go);
    }
    /// <summary>
    /// 컴포넌트에 T 컴포넌트를 추가하거나 찾습니다.
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
    /// 특정 월드 좌표에서 Terrain의 노멀 벡터를 가져옵니다.
    /// </summary>
    /// <param name="terrain">노멀 벡터를 가져올 Terrain</param>
    /// <param name="worldPosition">노멀 벡터를 가져올 월드 좌표</param>
    /// <returns>지정된 위치의 노멀 벡터</returns>
    public static Vector3 GetNormalAtWorldPosition(this Terrain terrain, Vector3 worldPosition)
    {
        if (terrain == null)
        {
            Debug.LogError("Terrain is null. Please provide a valid Terrain.");
            return Vector3.up; // 기본값으로 위쪽 방향 벡터 반환
        }

        TerrainData terrainData = terrain.terrainData;
        Vector3 terrainPosition = terrain.transform.position;
        Vector3 terrainSize = terrainData.size;

        // 월드 좌표를 Terrain의 상대 좌표로 변환
        float relativeX = (worldPosition.x - terrainPosition.x) / terrainSize.x;
        float relativeZ = (worldPosition.z - terrainPosition.z) / terrainSize.z;

        // 상대 좌표가 0~1 범위 내에 있는지 확인
        if (relativeX < 0 || relativeX > 1 || relativeZ < 0 || relativeZ > 1)
        {
            Debug.LogWarning("World position is out of terrain bounds.");
            return Vector3.up; // 범위를 벗어난 경우 기본값으로 위쪽 방향 벡터 반환
        }

        // 상대 좌표를 사용하여 노멀 벡터 가져오기
        Vector3 normal = terrainData.GetInterpolatedNormal(relativeX, relativeZ);
        return normal;
    }

}

