using UnityEngine;

namespace Controller
{
    public interface ICustomInput
    {
        public abstract void InputKeyCode(KeyCode keyCode, bool flag, Vector3 mousePosition);
    }
}