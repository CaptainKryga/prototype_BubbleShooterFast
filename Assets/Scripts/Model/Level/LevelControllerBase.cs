using UnityEngine;
using View.Game;

namespace Model.Level
{
    public abstract class LevelControllerBase : MonoBehaviour
    {
        [SerializeField] protected MenuGameBase PanelMenu;
        
        private int _score;
        private bool _isWin;
        [SerializeField] private int _countCircles;

        public int Score
        {
            get => _score;
        }

        public bool IsWin
        {
            get => _isWin;
        }

        public int CountCircles
        {
            get => _countCircles;
            set
            {
                _countCircles = value;
                _score++;
                if (_countCircles <= 0)
                {
                    _isWin = true;
                    GameOver();
                }
            }
        }

        public abstract void InitLevel(int levelId);
        public abstract void GameOver();
    }
}