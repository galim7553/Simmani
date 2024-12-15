using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Poolable : MonoBehaviour
{
    Pool _pool;

    public void SetPool(Pool pool)
    {
        _pool = pool;
    }

    public void ReturnToPool()
    {
        if (_pool != null)
            _pool.Push(gameObject);
    }
}
