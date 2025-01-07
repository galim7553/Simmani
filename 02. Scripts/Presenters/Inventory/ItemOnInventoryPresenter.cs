using System;
using System.Collections.Generic;
using GamePlay.Components;
using GamePlay.Datas;
using GamePlay.Views;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GamePlay.Presenters
{
    /// <summary>
    /// �κ��丮 �� �������� �����ϴ� ��������.
    /// </summary>
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

        /// <summary>
        /// �ʱ�ȭ �޼���.
        /// </summary>
        void Initialize()
        {
            BindPointerDownEvents();
            BindDragDropEvents();
            UpdateImage();
            SetIsDraggable(false);
        }

        /// <summary>
        /// �巡�� ���� ���θ� �����մϴ�.
        /// </summary>
        public void SetIsDraggable(bool isDraggable)
        {
            _isDraggable = isDraggable;
            _dragDropHandler.SetActive(_isDraggable);
        }

        /// <summary>
        /// �������� ��Ŀ�� �������� �����մϴ�.
        /// </summary>
        public void SetIsFocused(bool isFocused)
        {
            _view.SetAlphaOutlineActive(isFocused);
        }


        /// <summary>
        /// PointerDown �̺�Ʈ�� ���ε��մϴ�.
        /// </summary>
        void BindPointerDownEvents()
        {
            _pointerDownHandler = _view.GetOrAddComponent<PointerDownHandler>();
            _pointerDownHandler.OnPointerDowned += OnPointerDowned;
        }

        /// <summary>
        /// DragDrop �̺�Ʈ�� ���ε��մϴ�.
        /// </summary>
        void BindDragDropEvents()
        {
            _dragDropHandler = _view.GetOrAddComponent<DragDropHandler>();
            _dragDropHandler.Initialize();
            _dragDropHandler.OnDragBegun += OnDragBegun;
            _dragDropHandler.OnDropped += OnDropped;
        }

        /// <summary>
        /// ������ �̹����� �����մϴ�.
        /// </summary>
        void UpdateImage()
        {
            _view.SetImage((int)ItemOnInventoryView.ImageKey.ItemImage, GetResource<Sprite>(_model.Config.SpritePath));
        }

        /// <summary>
        /// �������� ���õǾ��� �� ȣ��˴ϴ�.
        /// </summary>
        void OnPointerDowned()
        {
            OnItemFocused?.Invoke(this);
        }

        /// <summary>
        /// ������ �巡�װ� ���۵Ǿ��� �� ȣ��˴ϴ�.
        /// </summary>
        void OnDragBegun()
        {
            OnItemDragBegun?.Invoke(_model);
        }

        /// <summary>
        /// ������ �巡�װ� ����Ǿ��� �� ȣ��˴ϴ�.
        /// </summary>
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