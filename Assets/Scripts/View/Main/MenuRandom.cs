using Scriptables;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace View.Main
{
    public class MenuRandom : MenuMainBase
    {
        [SerializeField] private GameSettings _settings;
        [SerializeField] private TMPro.TMP_Text _textMaxScore;

        private void Start()
        {
            _textMaxScore.text = "Score: " + PlayerPrefs.GetInt("ScoreRandom", 0);
        }

        public void OnClick_Start()
        {
            _settings.IsCompany = false;
            _settings.LevelId = Random.Range(0, 100);
            SceneManager.LoadScene(1);
        }
    }
}