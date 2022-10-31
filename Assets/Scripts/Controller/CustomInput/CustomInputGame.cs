using UnityEngine;

namespace Controller.CustomInput
{
    public class CustomInputGame : CustomInputBase
    {
        protected override void SetupKeyboard()
        {
            //gun
            if (Input.GetKeyDown(KeyCode.Mouse0))
                InputMouse_Action?.Invoke(true, Input.mousePosition);
            
            //mobile?
            // if (Input.GetKeyUp(KeyCode.Mouse0))
                // InputMouse_Action?.Invoke(false, Input.mousePosition);
        }
    }
}
