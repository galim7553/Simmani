using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GamePlay.Views
{
    public class ViewBase : MonoBehaviour
    {
        protected Dictionary<Type, Component[]> _components = new Dictionary<Type, Component[]>();

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

        protected T Get<T>(int idx) where T : Component
        {
            if (_components.TryGetValue(typeof(T), out var components) == true
                && idx >= 0 && idx < components.Length)
                return components[idx] as T;

            Debug.LogError($"Component of type {typeof(T).Name} at index {idx} not found in {_components[typeof(T)]}.");
            return null;
        }

        public void SetTMP(int idx, string text)
        {
            TextMeshProUGUI tmp = GetTMP(idx);
            if (tmp)
                tmp.text = text;
        }
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

