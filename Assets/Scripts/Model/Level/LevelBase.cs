using Model.Gun;
using Scriptables;
using UnityEngine;
using View.Game;

namespace Model.Level
{
    public abstract class LevelBase : MonoBehaviour
    {
        [SerializeField] protected MenuGameBase PanelGameOver;

        [SerializeField] protected DataGame DataGame;
        [SerializeField] protected GunBase GunBase;
        [SerializeField] protected Stats Stats;
        
        [SerializeField] protected Transform Parent;
        [SerializeField] protected Circle Prefab;
        
        private int _countCircles;
        private bool _isPlay;
        
        public int CountCircles
        {
            get => _countCircles;
            set
            {
                if (_countCircles > value)
                    Stats.Score += _countCircles - value;
                
                _countCircles = value;
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
            set => _isPlay = value;
        }

        public void InitController(MenuGameBase panelGameOver, DataGame dataGame, Stats stats, 
            Transform parent, Circle prefab)
        {
            PanelGameOver = panelGameOver;
            DataGame = dataGame; 
            Stats = stats;
            Parent = parent;
            Prefab = prefab;
        }

        public void SyncGunBase(GunBase gunBase)
        {
            GunBase = gunBase;
            InitLevel(DataGame.GameSettings.LevelId);
        }
        
        protected abstract void InitLevel(int levelId);
        
        public void GameOver()
        {
            _isPlay = false;
            PanelGameOver.UsePanel();

            Stats.GameOver(DataGame.GameSettings.IsCompany);
        }

        public void Pause(bool flag)
        {
            _isPlay = !flag;
        }
    }
}