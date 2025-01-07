using UnityEngine;

/// <summary>
/// Ǯ���� ������Ʈ�� �����ϴ� Ŭ����.
/// Ǯ���� ������ ��ü�� Ǯ�� ��ȯ�� �� �ִ� ����� �����մϴ�.
/// </summary>
public class Poolable : MonoBehaviour
{
    // �� ������Ʈ�� ���� Ǯ
    private Pool _pool;

    /// <summary>
    /// �ش� ������Ʈ�� ���� Ǯ�� �����մϴ�.
    /// </summary>
    /// <param name="pool">������Ʈ�� ���� Ǯ</param>
    public void SetPool(Pool pool)
    {
        _pool = pool;
    }

    /// <summary>
    /// ������Ʈ�� Ǯ�� ��ȯ�մϴ�.
    /// </summary>
    public void ReturnToPool()
    {
        if (_pool != null)
        {
            _pool.Push(gameObject); // Ǯ�� ������Ʈ ��ȯ
        }
    }
}