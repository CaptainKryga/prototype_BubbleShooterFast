using Model.Level;
using Scriptables;
using UnityEngine;
using View.Game;

namespace Model
{
    public class StarterLevelController : MonoBehaviour
    {
        [SerializeField] protected MenuGameBase PanelGameOver;

        [SerializeField] protected DataGame DataGame;
        [SerializeField] protected GunController GunController;
        [SerializeField] protected Stats Stats;
        
        [SerializeField] protected Transform Parent;
        [SerializeField] protected Circle Prefab;

        public LevelControllerBase GetLevelController()
        {
            LevelControllerBase lc = DataGame.GameSettings.IsCompany ? 
                gameObject.AddComponent<LevelCompany>() :
                gameObject.AddComponent<LevelRandom>();
            lc.InitController(PanelGameOver, DataGame, GunController, Stats, Parent, Prefab);
            lc.InitLevel(DataGame.GameSettings.LevelId);
            return lc;
        }
    }
}