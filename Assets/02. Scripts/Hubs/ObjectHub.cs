using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace GamePlay.Hubs
{
    public abstract class ObjectHub : MonoBehaviour, ICoroutineRunner, IModuleHolder
    {
        public ModuleContainer Modules { get; private set; } = new ModuleContainer();

        public abstract void Initialize();
        protected void LogUninitializedModuleError()
        {
            Debug.LogError($"{gameObject.name}의 모듈들이 초기화되지 않았습니다.");
        }
        // ----- ICoroutineRunner ----- //
        public Coroutine RunCoroutine(IEnumerator coroutine)
        {
            return StartCoroutine(coroutine);
        }

        public Coroutine RunCoroutine(IEnumerator coroutine, Action callback)
        {
            return StartCoroutine(RunCoroutineWithCallbackCo(coroutine, callback));
        }

        public void StopCoroutineRunner(Coroutine coroutine)
        {
            StopCoroutine(coroutine);
        }

        IEnumerator RunCoroutineWithCallbackCo(IEnumerator coroutine, Action callback)
        {
            yield return coroutine;
            callback?.Invoke();
        }
        // ----- ICoroutineRunner ----- //

        public virtual void Clear()
        {
            Modules.Clear();
        }
        public void DestroyOrReturnToPool()
        {
            Clear();
            Poolable poolable = GetComponent<Poolable>();
            if (poolable != null)
                poolable.ReturnToPool();
            else
                Destroy(this);

        }


    }
}