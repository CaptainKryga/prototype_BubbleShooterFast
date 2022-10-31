using Scriptables;
using UnityEngine;
using View.Game;

namespace Model.Level
{
    public abstract class LevelControllerBase : MonoBehaviour
    {
        [SerializeField] protected MenuGameBase PanelGameOver;

        [SerializeField] protected DataGame DataGame;
        [SerializeField] protected GunController GunController;
        [SerializeField] protected Stats Stats;
        
        [SerializeField] protected Transform Parent;
        [SerializeField] protected Circle Prefab;
        
        [SerializeField] private int _countCircles;
        [SerializeField] protected bool _isPlay;
        
        public int CountCircles
        {
            get => _countCircles;
            set
            {
                _countCircles = value;
                Stats.Score++;
                if (_countCircles <= 0)
                {
                    Stats.IsWin = true;
                    GameOver();
                }
            }
        }

        public bool IsPlay
        {
            get => _isPlay;
        }

        public void InitController(MenuGameBase panelGameOver, DataGame dataGame, GunController gunController,
            Stats stats, Transform parent, Circle prefab)
        {
            PanelGameOver = panelGameOver;
            DataGame = dataGame;
            GunController = gunController;
            Stats = stats;
            Parent = parent;
            Prefab = prefab;
        }
        
        public abstract void InitLevel(int levelId);
        
        public void GameOver()
        {
            _isPlay = false;
            PanelGameOver.UsePanel();

            if (!DataGame.GameSettings.IsCompany)
                PlayerPrefs.SetInt("ScoreRandom", Stats.Score);
        }

        public void Pause(bool flag)
        {
            _isPlay = !flag;
        }
    }
}