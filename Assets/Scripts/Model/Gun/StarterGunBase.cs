using Controller.CustomInput;
using Model.Components;
using Model.Level;
using Scriptables;
using UnityEngine;

namespace Model.Gun
{
    public class StarterGunBase : MonoBehaviour
    {
        [SerializeField] protected DataGame DataGame;
        [SerializeField] protected CustomInputBase CustomInputBase;
        [SerializeField] protected Transform Parent;
        
        [SerializeField] protected Bullet Prefab;
        [SerializeField] protected float Speed;

        public GunBase GetGunBase(LevelBase levelBase)
        {
            GunBase gunController = DataGame.GameSettings.IsCompany ? 
                gameObject.AddComponent<GunCompany>() :
                gameObject.AddComponent<GunRandom>();
            gunController.InitGunBase(levelBase, DataGame, CustomInputBase, Parent, Prefab, Speed);
            return gunController;
        }
    }
}