using System;
using Controller.CustomInput;
using Model.Level;
using Scriptables;
using UnityEngine;

namespace Model.Gun
{
    public abstract class GunBase : MonoBehaviour
    {
        private Camera _camera;

        protected LevelControllerBase LevelController;
        protected Bullet Bullet;

        [SerializeField] protected DataGame DataGame;
        [SerializeField] protected CustomInputBase CustomInputBase;
        [SerializeField] protected Transform Parent;
        
        [SerializeField] protected Bullet Prefab;
        [SerializeField] protected float Speed;
        
        private void Awake()
        {
            _camera = Camera.main;
        }
        
        public void InitGunBase(LevelControllerBase levelController, DataGame dataGame,
            CustomInputBase customInputBase, Transform parent, Bullet prefab, float speed)
        {
            LevelController = levelController;
            DataGame = dataGame;
            CustomInputBase = customInputBase;
            Parent = parent;
            Prefab = prefab;
            Speed = speed;
            
            CustomInputBase.InputMouse_Action += InputMouse;
        }
        
        private void InputMouse(bool flag, Vector2 mousePosition)
        {
            if (!LevelController.IsPlay)
                return;
            
            if (flag)
            {
                Vector2 vec = (_camera.ScreenToWorldPoint(mousePosition) - Parent.position);
                vec.Normalize();
                
                Bullet.RigidBody.velocity = vec * Speed;

                GenNewBullet();
            }
        }
        
        public abstract void Init(int[] queue);
        protected abstract void GenNewBullet();

        private void OnDestroy()
        {
            CustomInputBase.InputMouse_Action -= InputMouse;
        }
    }
}