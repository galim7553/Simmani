using UnityEngine;

/// <summary>
/// 풀링된 오브젝트를 관리하는 클래스.
/// 풀에서 가져온 객체를 풀로 반환할 수 있는 기능을 제공합니다.
/// </summary>
public class Poolable : MonoBehaviour
{
    // 이 오브젝트가 속한 풀
    private Pool _pool;

    /// <summary>
    /// 해당 오브젝트가 속한 풀을 설정합니다.
    /// </summary>
    /// <param name="pool">오브젝트가 속한 풀</param>
    public void SetPool(Pool pool)
    {
        _pool = pool;
    }

    /// <summary>
    /// 오브젝트를 풀로 반환합니다.
    /// </summary>
    public void ReturnToPool()
    {
        if (_pool != null)
        {
            _pool.Push(gameObject); // 풀로 오브젝트 반환
        }
    }
}