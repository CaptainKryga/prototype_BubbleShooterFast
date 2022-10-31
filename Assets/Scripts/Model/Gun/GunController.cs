using Controller.CustomInput;
using Model.Level;
using Scriptables;
using UnityEngine;

namespace Model
{
    public class GunController : MonoBehaviour
    {
        [SerializeField] private DataGame _dataGame;
        private LevelControllerBase _levelController;

        [SerializeField] private CustomInputBase _customInputBase;
        
        [SerializeField] private Transform _gunPoint;
        private Camera _camera;

        [SerializeField] private Bullet _bullet;
        [SerializeField] private float _speed;

        private Bullet bullet;
        private int[] _queue;
        private int _colorId;
        
        private void Awake()
        {
            _camera = Camera.main;
        }

        public void Init(int[] queue)
        {
            _queue = queue;
            GenNewBullet();
        }

        private void OnEnable()
        {
            _customInputBase.InputMouse_Action += InputMouse;
        }

        private void OnDisable()
        {
            _customInputBase.InputMouse_Action -= InputMouse;
        }

        public void InputMouse(bool flag, Vector2 mousePosition)
        {
            if (!_levelController.IsPlay)
                return;
            
            Debug.Log("click");
            if (flag)
            {
                Vector2 vec = (_camera.ScreenToWorldPoint(mousePosition) - _gunPoint.position);
                vec.Normalize();
                
                bullet.RigidBody.velocity = vec * _speed;

                GenNewBullet();
            }
        }

        private void GenNewBullet()
        {
            bullet = Instantiate(_bullet, _gunPoint.position, Quaternion.identity, _gunPoint);
            bullet.Init(_levelController);
            bullet.Color = _dataGame.Colors[_queue[_colorId++]];
            if (_colorId >= _queue.Length) _colorId = 0;
        }
    }
}
