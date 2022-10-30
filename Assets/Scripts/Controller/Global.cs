using Model.Level;
using Scriptables;
using UnityEngine;

namespace Controller
{
    public class Global : MonoBehaviour
    {
        [SerializeField] private GameSettings _gameSettings;
        private LevelControllerBase _levelController;

        [SerializeField] private LevelControllerBase _company, _random;

        private void Start()
        {
            _levelController = _gameSettings.IsCompany ? _company : _random;
            
            _levelController.InitLevel(_gameSettings.LevelId);
        }
    }
}