using System;
using UnityEngine;

namespace Controller
{
    public class CustomInput : MonoBehaviour
    {
        public Action<Vector2> UpdateMouseRightDownClick_Action;
        public Action<Vector2> UpdateMouseRightUpClick_Action;
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
                UpdateMouseRightDownClick_Action?.Invoke(Input.mousePosition);
            
            if (Input.GetKeyUp(KeyCode.Mouse0))
                UpdateMouseRightUpClick_Action?.Invoke(Input.mousePosition);
        }
    }
}