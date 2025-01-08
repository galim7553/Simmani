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
    /// 인벤토리 내 아이템을 제어하는 프레젠터.
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
        /// 초기화 메서드.
        /// </summary>
        void Initialize()
        {
            BindPointerDownEvents();
            BindDragDropEvents();
            UpdateImage();
            SetIsDraggable(false);
        }

        /// <summary>
        /// 드래그 가능 여부를 설정합니다.
        /// </summary>
        public void SetIsDraggable(bool isDraggable)
        {
            _isDraggable = isDraggable;
            _dragDropHandler.SetActive(_isDraggable);
        }

        /// <summary>
        /// 아이템이 포커스 상태인지 설정합니다.
        /// </summary>
        public void SetIsFocused(bool isFocused)
        {
            _view.SetAlphaOutlineActive(isFocused);
        }


        /// <summary>
        /// PointerDown 이벤트를 바인딩합니다.
        /// </summary>
        void BindPointerDownEvents()
        {
            _pointerDownHandler = _view.GetOrAddComponent<PointerDownHandler>();
            _pointerDownHandler.OnPointerDowned += OnPointerDowned;
        }

        /// <summary>
        /// DragDrop 이벤트를 바인딩합니다.
        /// </summary>
        void BindDragDropEvents()
        {
            _dragDropHandler = _view.GetOrAddComponent<DragDropHandler>();
            _dragDropHandler.Initialize();
            _dragDropHandler.OnDragBegun += OnDragBegun;
            _dragDropHandler.OnDropped += OnDropped;
        }

        /// <summary>
        /// 아이템 이미지를 갱신합니다.
        /// </summary>
        void UpdateImage()
        {
            _view.SetImage((int)ItemOnInventoryView.ImageKey.ItemImage, GetResource<Sprite>(_model.Config.SpritePath));
        }

        /// <summary>
        /// 아이템이 선택되었을 때 호출됩니다.
        /// </summary>
        void OnPointerDowned()
        {
            OnItemFocused?.Invoke(this);
        }

        /// <summary>
        /// 아이템 드래그가 시작되었을 때 호출됩니다.
        /// </summary>
        void OnDragBegun()
        {
            OnItemDragBegun?.Invoke(_model);
        }

        /// <summary>
        /// 아이템 드래그가 종료되었을 때 호출됩니다.
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