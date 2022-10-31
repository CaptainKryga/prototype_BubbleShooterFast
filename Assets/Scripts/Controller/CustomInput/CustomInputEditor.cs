using UnityEngine;

namespace Controller.CustomInput
{
    public class CustomInputEditor : CustomInputBase
    {
        protected override void SetupKeyboard()
        {
            //gun
            if (Input.GetKeyDown(KeyCode.Mouse0))
                InputMouse_Action?.Invoke(true, Input.mousePosition);
            
            //export map
            if (Input.GetKeyDown(KeyCode.G))
                InputKeyboard_Action?.Invoke(KeyCode.G, true);
            
            //change color circle
            if (Input.GetKeyDown(KeyCode.Alpha1))
                InputKeyboard_Action?.Invoke(KeyCode.Alpha1, true);
            if (Input.GetKeyDown(KeyCode.Alpha2))
                InputKeyboard_Action?.Invoke(KeyCode.Alpha2, true);
            if (Input.GetKeyDown(KeyCode.Alpha3))
                InputKeyboard_Action?.Invoke(KeyCode.Alpha3, true);
            if (Input.GetKeyDown(KeyCode.Alpha4))
                InputKeyboard_Action?.Invoke(KeyCode.Alpha4, true);
            if (Input.GetKeyDown(KeyCode.Alpha5))
                InputKeyboard_Action?.Invoke(KeyCode.Alpha5, true);
            if (Input.GetKeyDown(KeyCode.Alpha6))
                InputKeyboard_Action?.Invoke(KeyCode.Alpha6, true);
        }
    }
}
