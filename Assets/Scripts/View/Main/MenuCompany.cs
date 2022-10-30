using Scriptables;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace View.Main
{
    public class MenuCompany : MenuMainBase
    {
        [SerializeField] private GameSettings _settings;
        [SerializeField] private Toggle _startToggle;

        private void Start()
        {
            _startToggle.Select();
        }

        public void OnToggle_SetLevel(int levelId)
        {
            _settings.LevelId = levelId;
        }

        public void OnClick_Start()
        {
            _settings.IsCompany = true;
            SceneManager.LoadScene(1);
        }
    }
}