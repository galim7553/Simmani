using System.Collections;
using System.Collections.Generic;
using GamePlay.Views;
using UnityEngine;

namespace GamePlay.Factories
{
    public class ViewFactory
    {
        PoolManager _poolManager;
        public ViewFactory(PoolManager poolManager)
        {
            _poolManager = poolManager;
        }

        public T CreateView<T>(string prefabPath) where T : ViewBase
        {
            return _poolManager.GetFromPool(prefabPath).GetOrAddComponent<T>();
        }
    }
}


