using Controller;
using Model.Level;
using Scriptables;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Model
{
    public class GunController : MonoBehaviour, ICustomInput
    {
        [SerializeField] private DataGame _dataGame;
        [SerializeField] private LevelControllerBase _levelControllerBase;
        
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
            CustomInput.Singleton.InputKeyCode_Action += InputKeyCode;
        }

        private void OnDisable()
        {
            CustomInput.Singleton.InputKeyCode_Action -= InputKeyCode;
        }

        public void InputKeyCode(KeyCode keyCode, bool flag, Vector3 mousePosition)
        {
            if (keyCode == KeyCode.Mouse0 && flag)
            {
                Vector2 vec = (_camera.ScreenToWorldPoint(Input.mousePosition) - _gunPoint.position);
                vec.Normalize();
                
                bullet.RigidBody.velocity = vec * _speed;

                GenNewBullet();
            }
        }

        private void GenNewBullet()
        {
            bullet = Instantiate(_bullet, _gunPoint.position, Quaternion.identity, _gunPoint);
            bullet.Init(_levelControllerBase);
            bullet.Color = _dataGame.Colors[_queue[_colorId++]];
            if (_colorId >= _queue.Length) _colorId = 0;
        }
    }
}
