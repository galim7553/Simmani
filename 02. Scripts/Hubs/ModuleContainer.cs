using System;
using System.Collections.Generic;
using GamePlay.Modules;
using UnityEngine;

namespace GamePlay.Hubs
{
    /// <summary>
    /// 게임 오브젝트에 연결된 모듈들을 관리하는 컨테이너 클래스.
    /// 모듈 등록, 검색, 초기화 및 정리를 담당.
    /// </summary>
    public class ModuleContainer
    {
        /// <summary>모듈 초기화 여부.</summary>
        public bool HasInitialized { get; private set; } = false;

        /// <summary>모듈 타입별로 모듈 배열을 저장하는 딕셔너리.</summary>
        Dictionary<Type, IModule[]> _moduleMap = new Dictionary<Type, IModule[]>();

        /// <summary>모든 모듈 초기화.</summary>
        public void Initialize()
        {
            HasInitialized = true;
        }

        /// <summary>단일 모듈 등록.</summary>
        public void Set<T>(IModule module) where T : class, IModule
        {
            if(_moduleMap.ContainsKey(typeof(T)) == true)
            {
                Debug.LogWarning($"이미 존재하는 모듈이기에 모듈 설정이 취소되었습니다. {typeof(T)}");
                return;
            }

            IModule[] modules = new IModule[1];
            modules[0] = module;
            _moduleMap[typeof(T)] = modules;
        }

        /// <summary>모듈 배열 등록.</summary>
        public void Set<T>(IModule[] modules) where T : class, IModule
        {
            if (_moduleMap.ContainsKey(typeof(T)) == true)
            {
                Debug.LogWarning($"이미 존재하는 모듈 배열이기에 모듈 배열 설정이 취소되었습니다. {typeof(T)}");
                return;
            }

            _moduleMap[typeof(T)] = modules;
        }

        /// <summary>단일 모듈 반환.</summary>
        public T Get<T>() where T : class, IModule
        {
            IModule[] modules;
            if (_moduleMap.TryGetValue(typeof(T), out modules) == true)
                return modules[0] as T;
            Debug.LogError($"존재하지 않는 모듈입니다. {typeof(T)}");
            return null;
        }

        /// <summary>모듈 배열에서 특정 인덱스의 모듈 반환.</summary>
        public T Get<T>(int index) where T : class, IModule
        {
            IModule[] modules;
            if (_moduleMap.TryGetValue(typeof(T), out modules) == true)
                return modules[index] as T;
            Debug.LogError($"존재하지 않는 모듈 배열입니다. {typeof(T)}");
            return null;
        }

        public void Clear()
        {
            foreach(IModule[] modules in _moduleMap.Values)
            {
                foreach(IModule module in modules)
                    module.Clear();
            }
            _moduleMap.Clear();
            HasInitialized = false;
        }
    }
}