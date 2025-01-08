using System.Collections;
using UnityEngine;
using System;

namespace GamePlay.Hubs
{
    /// <summary>
    /// ���� ������Ʈ�� �ٽ� ���̽� Ŭ����.
    /// ��� ����, �ڷ�ƾ ���� �� ���� �۾��� ���.
    /// </summary>
    public abstract class ObjectHub : MonoBehaviour, ICoroutineRunner, IModuleHolder
    {
        /// <summary>�� ������Ʈ�� ����� ��� �����̳�.</summary>
        public ModuleContainer Modules { get; private set; } = new ModuleContainer();

        /// <summary>������Ʈ �ʱ�ȭ �޼���. �� �Ļ� Ŭ�������� ���� �ʿ�.</summary
        public abstract void Initialize();

        /// <summary>��� �ʱ�ȭ ���� �α� ���.</summary>
        protected void LogUninitializedModuleError()
        {
            Debug.LogError($"{gameObject.name}�� ������ �ʱ�ȭ���� �ʾҽ��ϴ�.");
        }


        // ----- ICoroutineRunner ----- //
        /// <summary>�ڷ�ƾ ����.</summary>
        public Coroutine RunCoroutine(IEnumerator coroutine)
        {
            return StartCoroutine(coroutine);
        }

        /// <summary>�ڷ�ƾ ���� �� �ݹ� ����.</summary>
        public Coroutine RunCoroutine(IEnumerator coroutine, Action callback)
        {
            return StartCoroutine(RunCoroutineWithCallbackCo(coroutine, callback));
        }

        /// <summary>���� ���� �ڷ�ƾ �ߴ�.</summary>
        public void StopCoroutineRunner(Coroutine coroutine)
        {
            StopCoroutine(coroutine);
        }

        /// <summary>�ݹ��� ������ �ڷ�ƾ ���� ����.</summary>
        IEnumerator RunCoroutineWithCallbackCo(IEnumerator coroutine, Action callback)
        {
            yield return coroutine;
            callback?.Invoke();
        }
        // ----- ICoroutineRunner ----- //

        /// <summary>������Ʈ ���� �� ��� ��� ����.</summary>
        public virtual void Clear()
        {
            Modules.Clear();
        }

        /// <summary>������Ʈ�� Ǯ�� ��ȯ�ϰų� ����.</summary>
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