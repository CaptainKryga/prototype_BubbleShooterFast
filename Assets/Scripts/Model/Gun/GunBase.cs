using System;
using Controller.CustomInput;
using Model.Components;
using Model.Level;
using Scriptables;
using UnityEngine;

namespace Model.Gun
{
    public abstract class GunBase : MonoBehaviour
    {
        [SerializeField] protected DataGame DataGame;
        [SerializeField] protected CustomInputBase CustomInputBase;
        [SerializeField] protected Transform Parent;
        
        [SerializeField] protected Bullet Prefab;
        [SerializeField] protected float Speed;
        
        protected LevelBase Level;
        protected Bullet Bullet;
        
        private Camera _camera;

        private void Awake()
        {
            _camera = Camera.main;
        }
        
        public void InitGunBase(LevelBase level, DataGame dataGame,
            CustomInputBase customInputBase, Transform parent, Bullet prefab, float speed)
        {
            Level = level;
            DataGame = dataGame;
            CustomInputBase = customInputBase;
            Parent = parent;
            Prefab = prefab;
            Speed = speed;
            
            CustomInputBase.InputMouse_Action += InputMouse;
        }
        
        private void InputMouse(bool flag, Vector2 mousePosition)
        {
            if (!Level.IsPlay)
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