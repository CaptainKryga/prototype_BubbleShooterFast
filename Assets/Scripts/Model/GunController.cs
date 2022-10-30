using System;
using Controller;
using Scriptables;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Model
{
    public class GunController : MonoBehaviour, ICustomInput
    {
        [SerializeField] private DataGame _dataGame;
        
        [SerializeField] private Transform _gunPoint;
        private Camera _camera;

        [SerializeField] private Bullet _bullet;
        [SerializeField] private float _speed;

        private Bullet bullet;
        
        private void Awake()
        {
            _camera = Camera.main;
        }

        private void Start()
        {
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
            Debug.Log("click: " + keyCode);
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
            bullet.Color = _dataGame.Colors[Random.Range(0, _dataGame.Colors.Length)];
        }
    }
}
