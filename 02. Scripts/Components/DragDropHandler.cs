using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace GamePlay.Components
{
    [RequireComponent(typeof(RectTransform))]
    public class DragDropHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        bool _hasInitialized = false;
        bool _isActive = true;
        RectTransform _rectTransform;

        ScrollRect _scrollRect;
        Canvas _canvas;
        GraphicRaycaster _graphicRaycaster;
        Transform _parent;
        int _childIndex = -1;

        public event Action OnDragBegun;
        public event Action<List<RaycastResult>> OnDropped;

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
        }
        public void Initialize()
        {
            _scrollRect = GetComponentInParent<ScrollRect>(true);
            _canvas = GetComponentInParent<Canvas>();
            _graphicRaycaster = _canvas.GetComponent<GraphicRaycaster>();
            _parent = transform.parent;
            _childIndex = transform.GetSiblingIndex();

            _hasInitialized = _scrollRect != null && _canvas != null && _graphicRaycaster != null
                && _parent != null && _childIndex >= 0;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (_isActive == false) return;

            if(_hasInitialized == false) return;

            _scrollRect.enabled = false;
            transform.SetParent(_canvas.transform, true);

            OnDragBegun?.Invoke();
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (_isActive == false) return;
            if (_hasInitialized == false) return;

            // 드래그 동작
            _rectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (_isActive == false) return;
            if (_hasInitialized == false) return;

            _scrollRect.enabled = true;
            _rectTransform.SetParent(_parent, true);
            _rectTransform.SetSiblingIndex(_childIndex);

            List<RaycastResult> results = new List<RaycastResult>();
            _graphicRaycaster.Raycast(eventData, results);

            if (results.Count > 0)
                OnDropped?.Invoke(results);
        }

        public void SetActive(bool isActive)
        {
            _isActive = isActive;
        }

        public void Clear()
        {
            _scrollRect = null;
            _canvas = null;
            _graphicRaycaster = null;
            _parent = null;
            _childIndex = -1;

            _hasInitialized = false;
            _isActive = false;

            OnDragBegun = null;
            OnDropped = null;
        }
    }
}