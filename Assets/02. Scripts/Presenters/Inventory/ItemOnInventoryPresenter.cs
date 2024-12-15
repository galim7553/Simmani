using System;
using System.Collections;
using System.Collections.Generic;
using GamePlay.Components;
using GamePlay.Datas;
using GamePlay.Views;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GamePlay.Presenters
{
    public class ItemOnInventoryPresenter : ResourceDependentPresenterBase<IItemModel, ItemOnInventoryView>
    {
        PointerDownHandler _pointerDownHandler;
        DragDropHandler _dragDropHandler;
        bool _isDraggable = false;

        public IItemModel Model => _model;

        public event Action<ItemOnInventoryPresenter> OnItemFocused;
        public event Action<IItemModel> OnItemDragBegun;
        public event Action<IItemModel, List<RaycastResult>> OnItemDropped;
       

        public ItemOnInventoryPresenter(IItemModel model, ItemOnInventoryView view) : base(model, view)
        {
            Initialize();
        }

        void Initialize()
        {
            BindPointerDownEvents();
            BindDragDropEvents();
            UpdateImage();
            SetIsDraggable(false);
        }

        public void SetIsDraggable(bool isDraggable)
        {
            _isDraggable = isDraggable;
            _dragDropHandler.SetActive(_isDraggable);
        }
        public void SetIsFocused(bool isFocused)
        {
            _view.SetAlphaOutlineActive(isFocused);
        }

        void BindPointerDownEvents()
        {
            _pointerDownHandler = _view.GetOrAddComponent<PointerDownHandler>();
            _pointerDownHandler.OnPointerDowned += OnPointerDowned;
        }
        void BindDragDropEvents()
        {
            _dragDropHandler = _view.GetOrAddComponent<DragDropHandler>();
            _dragDropHandler.Initialize();
            _dragDropHandler.OnDragBegun += OnDragBegun;
            _dragDropHandler.OnDropped += OnDropped;
        }

        void UpdateImage()
        {
            _view.SetImage((int)ItemOnInventoryView.ImageKey.ItemImage, GetResource<Sprite>(_model.Config.SpritePath));
        }

        void OnPointerDowned()
        {
            OnItemFocused?.Invoke(this);
        }
        void OnDragBegun()
        {
            OnItemDragBegun?.Invoke(_model);
        }
        void OnDropped(List<RaycastResult> results)
        {
            OnItemDropped?.Invoke(_model, results);
        }

        public override void Clear()
        {
            base.Clear();

            OnItemFocused = null;
            OnItemDragBegun = null;
            OnItemDropped = null;
            _pointerDownHandler.Clear();
            _dragDropHandler.Clear();
            _view.DestroyOrReturnToPool();
        }
    }
}