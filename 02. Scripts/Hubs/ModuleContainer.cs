using System;
using System.Collections.Generic;
using GamePlay.Modules;
using UnityEngine;

namespace GamePlay.Hubs
{
    /// <summary>
    /// ���� ������Ʈ�� ����� ������ �����ϴ� �����̳� Ŭ����.
    /// ��� ���, �˻�, �ʱ�ȭ �� ������ ���.
    /// </summary>
    public class ModuleContainer
    {
        /// <summary>��� �ʱ�ȭ ����.</summary>
        public bool HasInitialized { get; private set; } = false;

        /// <summary>��� Ÿ�Ժ��� ��� �迭�� �����ϴ� ��ųʸ�.</summary>
        Dictionary<Type, IModule[]> _moduleMap = new Dictionary<Type, IModule[]>();

        /// <summary>��� ��� �ʱ�ȭ.</summary>
        public void Initialize()
        {
            HasInitialized = true;
        }

        /// <summary>���� ��� ���.</summary>
        public void Set<T>(IModule module) where T : class, IModule
        {
            if(_moduleMap.ContainsKey(typeof(T)) == true)
            {
                Debug.LogWarning($"�̹� �����ϴ� ����̱⿡ ��� ������ ��ҵǾ����ϴ�. {typeof(T)}");
                return;
            }

            IModule[] modules = new IModule[1];
            modules[0] = module;
            _moduleMap[typeof(T)] = modules;
        }

        /// <summary>��� �迭 ���.</summary>
        public void Set<T>(IModule[] modules) where T : class, IModule
        {
            if (_moduleMap.ContainsKey(typeof(T)) == true)
            {
                Debug.LogWarning($"�̹� �����ϴ� ��� �迭�̱⿡ ��� �迭 ������ ��ҵǾ����ϴ�. {typeof(T)}");
                return;
            }

            _moduleMap[typeof(T)] = modules;
        }

        /// <summary>���� ��� ��ȯ.</summary>
        public T Get<T>() where T : class, IModule
        {
            IModule[] modules;
            if (_moduleMap.TryGetValue(typeof(T), out modules) == true)
                return modules[0] as T;
            Debug.LogError($"�������� �ʴ� ����Դϴ�. {typeof(T)}");
            return null;
        }

        /// <summary>��� �迭���� Ư�� �ε����� ��� ��ȯ.</summary>
        public T Get<T>(int index) where T : class, IModule
        {
            IModule[] modules;
            if (_moduleMap.TryGetValue(typeof(T), out modules) == true)
                return modules[index] as T;
            Debug.LogError($"�������� �ʴ� ��� �迭�Դϴ�. {typeof(T)}");
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