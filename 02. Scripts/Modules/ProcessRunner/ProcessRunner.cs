using System;
using System.Collections;
using GamePlay.Hubs;
using UnityEngine;

namespace GamePlay.Modules
{
    /// <summary>
    /// 작업 실행을 관리하는 기본 클래스입니다.
    /// </summary>
    public class ProcessRunner : ModuleBase, IProcessRunner
    {
        ICoroutineRunner _runner;

        public event Action OnBegan;
        public event Action<float> OnProcess;
        public event Action OnEnded;

        public bool IsRunning { get; private set; } = false;

        Coroutine _processing;
        IProcessable _curProcessable;

        public ProcessRunner(ICoroutineRunner runner)
        {
            _runner = runner;
        }


        public void Begin(IProcessable processable)
        {
            if (IsRunning == true) return;

            _curProcessable = processable;
            OnBegan?.Invoke();
            IsRunning = true;
            _processing = _runner.RunCoroutine(Processing(processable.Amount, processable.OnSuccess), End);
        }
        public void BeginWithExternalControl(IProcessable processable)
        {
            if (IsRunning == true) return;

            _curProcessable = processable;
            OnBegan?.Invoke();
            IsRunning = true;
        }

        IEnumerator Processing(float amount, Action onSuccess)
        {
            float elapsedTime = 0.0f;
            while (elapsedTime < amount)
            {
                elapsedTime += Time.deltaTime;
                OnProcess?.Invoke(elapsedTime / amount);
                yield return null;
            }
            onSuccess?.Invoke();
        }

        public void Fail()
        {
            if (_curProcessable != null)
                _curProcessable.OnFailed?.Invoke();
            End();

        }
        public void End()
        {
            if(_processing != null)
            {
                _runner.StopCoroutineRunner(_processing);
            }
            OnEnded?.Invoke();
            IsRunning = false;
            _processing = null;
            _curProcessable = null;
        }

        public override void Clear()
        {
            base.Clear();

            if (_processing != null)
                _runner.StopCoroutineRunner(_processing);
            _processing = null;

            OnBegan = null;
            OnProcess = null;
            OnEnded = null;

            _curProcessable = null;
        }
    }
}


