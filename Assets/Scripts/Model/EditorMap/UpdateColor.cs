using Controller;
using Controller.CustomInput;
using Model.Components;
using Scriptables;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Model.EditorMap
{
    public class UpdateColor : MonoBehaviour
    {
        [SerializeField] private DataGame _dataGame;
        [SerializeField] private CustomInputBase _customInputBase;

        private Color _color;
        private Camera _camera;

        private void Awake()
        {
            _camera = Camera.main;
        }

        private void OnEnable()
        {
            _customInputBase.InputMouse_Action += MouseClick;
            _customInputBase.InputKeyboard_Action += KeyboardClick;
        }

        private void OnDisable()
        {
            _customInputBase.InputMouse_Action -= MouseClick;
            _customInputBase.InputKeyboard_Action -= KeyboardClick;
        }

        private void MouseClick(bool flag, Vector2 mousePosition)
        {
            RaycastHit2D hit = Physics2D.Raycast(
                _camera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if(hit.collider != null)
            {
                Circle circle = hit.collider.GetComponent<Circle>();
                if (circle) circle.Color = _color;
            }
        }
        
        private void KeyboardClick(KeyCode key, bool flag)
        {
            if (key == KeyCode.Alpha1)
                _color = _dataGame.Colors[0];
            if (key == KeyCode.Alpha2)
                _color = _dataGame.Colors[1];
            if (key == KeyCode.Alpha3)
                _color = _dataGame.Colors[2];
            if (key == KeyCode.Alpha4)
                _color = _dataGame.Colors[3];
            if (key == KeyCode.Alpha5)
                _color = _dataGame.Colors[4];
            if (key == KeyCode.Alpha6)
                _color = _dataGame.Colors[5];
        }
    }
}
