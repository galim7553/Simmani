using System.Collections;
using UnityEngine;
using System;

namespace GamePlay.Hubs
{
    /// <summary>
    /// 게임 오브젝트의 핵심 베이스 클래스.
    /// 모듈 관리, 코루틴 실행 및 정리 작업을 담당.
    /// </summary>
    public abstract class ObjectHub : MonoBehaviour, ICoroutineRunner, IModuleHolder
    {
        /// <summary>이 오브젝트에 연결된 모듈 컨테이너.</summary>
        public ModuleContainer Modules { get; private set; } = new ModuleContainer();

        /// <summary>오브젝트 초기화 메서드. 각 파생 클래스에서 구현 필요.</summary
        public abstract void Initialize();

        /// <summary>모듈 초기화 오류 로그 출력.</summary>
        protected void LogUninitializedModuleError()
        {
            Debug.LogError($"{gameObject.name}의 모듈들이 초기화되지 않았습니다.");
        }


        // ----- ICoroutineRunner ----- //
        /// <summary>코루틴 실행.</summary>
        public Coroutine RunCoroutine(IEnumerator coroutine)
        {
            return StartCoroutine(coroutine);
        }

        /// <summary>코루틴 실행 후 콜백 실행.</summary>
        public Coroutine RunCoroutine(IEnumerator coroutine, Action callback)
        {
            return StartCoroutine(RunCoroutineWithCallbackCo(coroutine, callback));
        }

        /// <summary>실행 중인 코루틴 중단.</summary>
        public void StopCoroutineRunner(Coroutine coroutine)
        {
            StopCoroutine(coroutine);
        }

        /// <summary>콜백을 포함한 코루틴 실행 로직.</summary>
        IEnumerator RunCoroutineWithCallbackCo(IEnumerator coroutine, Action callback)
        {
            yield return coroutine;
            callback?.Invoke();
        }
        // ----- ICoroutineRunner ----- //

        /// <summary>오브젝트 정리 및 모든 모듈 제거.</summary>
        public virtual void Clear()
        {
            Modules.Clear();
        }

        /// <summary>오브젝트를 풀로 반환하거나 삭제.</summary>
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