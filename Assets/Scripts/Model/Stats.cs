using UnityEngine;

namespace Model
{
    public class Stats : MonoBehaviour
    {
        private bool _isWin;
        private int _score;

        public bool IsWin
        {
            get => _isWin;
            set => _isWin = value;
        }

        public int Score
        {
            get => _score;
            set => _score += value;
        }

        public void GameOver(bool isCompany)
        {
            if (isCompany)
                return;

            int old = PlayerPrefs.GetInt("ScoreRandom", 0);
            if (Score > old)
                PlayerPrefs.SetInt("ScoreRandom", Score);
        }
    }
}
