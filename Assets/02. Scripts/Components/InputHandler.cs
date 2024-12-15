using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Components
{
    public class InputHandler : MonoBehaviour
    {
        const string HORIZONTAL_AXIS = "Horizontal";
        const string VERTICAL_AXIS = "Vertical";

        const string MOUSE_X_AXIS = "Mouse X";
        const string MOUSE_Y_AXIS = "Mouse Y";

        public event Action<Vector2> OnMove;
        public event Action<Vector2> OnMouseMove;
        public event Action OnJump;
        public event Action OnLeftClick;
        public event Action OnRightClick;
        public event Action<bool> OnSprint;
        public event Action<int> OnHotKeyDown;
        public event Action OnInteraction;
        public event Action OnInventoryMenu;
        public event Action OnEscape;

        Vector2 _moveVector = Vector2.zero;
        Vector2 _mouseVector = Vector2.zero;

        private void Update()
        {
            _mouseVector.x = Input.GetAxis(MOUSE_X_AXIS);
            _mouseVector.y = Input.GetAxis(MOUSE_Y_AXIS);
            OnMouseMove?.Invoke(_mouseVector);

            _moveVector.x = Input.GetAxis(HORIZONTAL_AXIS);
            _moveVector.y = Input.GetAxis(VERTICAL_AXIS);
            OnMove?.Invoke(_moveVector);

            if (Input.GetButtonDown("Jump"))
                OnJump?.Invoke();

            if (Input.GetButtonDown("Sprint"))
                OnSprint?.Invoke(true);
            if (Input.GetButtonUp("Sprint"))
                OnSprint?.Invoke(false);

            for(int i = (int)KeyCode.Alpha1; i <= (int)KeyCode.Alpha9; i++)
                if(Input.GetKeyDown((KeyCode)i))
                    OnHotKeyDown(i - (int)KeyCode.Alpha1);

            if(Input.GetButtonDown("Interaction"))
                OnInteraction?.Invoke();

            if(Input.GetButtonDown("InventoryMenu"))
                OnInventoryMenu?.Invoke();

            if(Input.GetButtonDown("Cancel"))
                OnEscape?.Invoke();

            if(Input.GetMouseButtonDown(0))
                OnLeftClick?.Invoke();
            if(Input.GetMouseButtonDown(1))
                OnRightClick?.Invoke();
        }

        public void Clear()
        {
            OnMove = null;
            OnMouseMove = null;
            OnJump = null;
            OnLeftClick = null;
            OnRightClick = null;
            OnSprint = null;
            OnHotKeyDown = null;
            OnInteraction = null;
            OnInventoryMenu = null;
        }
    }
}


