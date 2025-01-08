using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Hubs
{
    public interface ICoroutineRunner
    {
        Coroutine RunCoroutine(IEnumerator coroutine);
        Coroutine RunCoroutine(IEnumerator coroutine, Action callback);
        void StopCoroutineRunner(Coroutine coroutine);
    }
}