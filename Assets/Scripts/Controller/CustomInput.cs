using System;
using UnityEngine;

namespace Controller
{
    public class CustomInput : MonoBehaviour
    {
        public static CustomInput Singleton { private set; get; }
        
        public Action<Vector2> UpdateMouseRightDownClick_Action;
        public Action<Vector2> UpdateMouseRightUpClick_Action;

        //keycode, isDownKey?
        public Action<KeyCode, bool, Vector3> InputKeyCode_Action;

        private void Awake()
        {
            Singleton = this;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                UpdateMouseRightDownClick_Action?.Invoke(Input.mousePosition);
                InputKeyCode_Action?.Invoke(KeyCode.Mouse0, true, Input.mousePosition);
            }
            
            if (Input.GetKeyUp(KeyCode.Mouse0))
                UpdateMouseRightUpClick_Action?.Invoke(Input.mousePosition);
            
            if (Input.GetKeyDown(KeyCode.G))
                InputKeyCode_Action?.Invoke(KeyCode.G, true, Input.mousePosition);
            
            if (Input.GetKeyDown(KeyCode.Alpha1))
                InputKeyCode_Action?.Invoke(KeyCode.Alpha1, true, Input.mousePosition);
            
            if (Input.GetKeyDown(KeyCode.Alpha2))
                InputKeyCode_Action?.Invoke(KeyCode.Alpha2, true, Input.mousePosition);
            
            if (Input.GetKeyDown(KeyCode.Alpha3))
                InputKeyCode_Action?.Invoke(KeyCode.Alpha3, true, Input.mousePosition);
            
            if (Input.GetKeyDown(KeyCode.Alpha4))
                InputKeyCode_Action?.Invoke(KeyCode.Alpha4, true, Input.mousePosition);
            
            if (Input.GetKeyDown(KeyCode.Alpha5))
                InputKeyCode_Action?.Invoke(KeyCode.Alpha5, true, Input.mousePosition);
        }
    }
}