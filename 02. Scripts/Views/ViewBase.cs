using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GamePlay.Views
{
    /// <summary>
    /// UI 뷰를 관리하는 기본 클래스.
    /// </summary>
    public class ViewBase : MonoBehaviour
    {
        // 바인딩된 컴포넌트를 저장하는 딕셔너리
        protected Dictionary<Type, Component[]> _components = new Dictionary<Type, Component[]>();

        /// <summary>
        /// 특정 타입의 컴포넌트를 enum에 바인딩.
        /// </summary>
        protected void Bind<T>(Type type) where T : Component
        {
            string[] names = Enum.GetNames(type);
            Dictionary<string, int> nameMap = new Dictionary<string, int>();
            for(int i = 0; i < names.Length; i++)
                nameMap[names[i]] = i;

            Component[] components = new Component[names.Length];
            _components[typeof(T)] = components;

            Component[] founds = GetComponentsInChildren<T>(true);
            foreach(var found in founds)
            {
                if(nameMap.TryGetValue(found.name, out var idx))
                    components[idx] = found;
            }
        }


        /// <summary>
        /// 바인딩된 컴포넌트 반환.
        /// </summary>
        protected T Get<T>(int idx) where T : Component
        {
            if (_components.TryGetValue(typeof(T), out var components) == true
                && idx >= 0 && idx < components.Length)
                return components[idx] as T;

            Debug.LogError($"Component of type {typeof(T).Name} at index {idx} not found in {_components[typeof(T)]}.");
            return null;
        }

        /// <summary>
        /// TextMeshProUGUI 텍스트 설정.
        /// </summary>
        public void SetTMP(int idx, string text)
        {
            TextMeshProUGUI tmp = GetTMP(idx);
            if (tmp)
                tmp.text = text;
        }

        /// <summary>
        /// Image 스프라이트 설정.
        /// </summary>
        public void SetImage(int idx, Sprite sprite)
        {
            Image image = GetImage(idx);
            if(image)
                image.sprite = sprite;
        }

        protected Text GetText(int idx)
        {
            return Get<Text>(idx);
        }
        protected Button GetButton(int idx)
        {
            return Get<Button>(idx);
        }
        protected Image GetImage(int idx)
        {
            return Get<Image>(idx);
        }
        protected TextMeshProUGUI GetTMP(int idx)
        {
            return Get<TextMeshProUGUI>(idx);
        }
        protected Transform GetTransform(int idx)
        {
            return Get<Transform>(idx);
        }

        public virtual void Clear()
        {

        }

        /// <summary>
        /// 뷰 제거 또는 풀에 반환.
        /// </summary>
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


