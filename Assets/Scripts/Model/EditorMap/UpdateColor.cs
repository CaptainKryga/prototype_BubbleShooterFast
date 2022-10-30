using Controller;
using Scriptables;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Model.EditorMap
{
    public class UpdateColor : MonoBehaviour
    {
        [SerializeField] private DataGame _dataGame;
        [SerializeField] private CustomInput _customInput;
        
        private Camera _camera;

        private void Awake()
        {
            _camera = Camera.main;
        }

        private void OnEnable()
        {
            _customInput.UpdateMouseRightDownClick_Action += MouseClick;
        }

        private void OnDisable()
        {
            _customInput.UpdateMouseRightDownClick_Action -= MouseClick;
        }

        private void MouseClick(Vector2 mousePosition)
        {
            RaycastHit2D hit = Physics2D.Raycast(
                _camera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if(hit.collider != null)
            {
                Circle circle = hit.collider.GetComponent<Circle>();
                if (circle) circle.Color = _dataGame.Colors[Random.Range(0, _dataGame.Colors.Length)];
            }
        }
    }
}
