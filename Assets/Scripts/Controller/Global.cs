using Model.Level;
using Scriptables;
using UnityEngine;

namespace Controller
{
    public class Global : MonoBehaviour
    {
        [SerializeField] private DataGame _dataGame;

        private LevelControllerBase _levelController;
        [SerializeField] private LevelControllerBase _company, _random;

        private void Start()
        {
            _levelController = _dataGame.GameSettings.IsCompany ? _company : _random;
            if (_levelController == _company) 
                _random.enabled = false;
            else 
                _company.enabled = false;

            _levelController.InitLevel(_dataGame.GameSettings.LevelId);
        }

        public void Pause(bool flag)
        {
            _levelController.Pause(flag);
        }
    }
}