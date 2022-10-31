using UnityEngine;
using View.Game;

namespace Model.Level
{
    public abstract class LevelControllerBase : MonoBehaviour
    {
        [SerializeField] protected MenuGameBase PanelMenu;
        
        private int _score;
        private bool _isWin;

        public int Score
        {
            get => _score;
        }

        public bool IsWin
        {
            get => _isWin;
        }

        public abstract void InitLevel(int levelId);
        public abstract void GameOver();
    }
}