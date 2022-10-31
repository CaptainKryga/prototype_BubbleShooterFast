using Model.Environment;
using Model.Gun;
using Model.Level;
using UnityEngine;

namespace Controller
{
    public class Global : MonoBehaviour
    {
        [SerializeField] private StarterLevelBase starterLevelBase;
        [SerializeField] private StarterGunBase _starterGunBase;
        [SerializeField] private GameOverPoint _gameOverPoint;

        private LevelBase _level;

        private void Awake()
        {
            _level = starterLevelBase.GetLevelController();
            _level.SyncGunBase(_starterGunBase.GetGunBase(_level));
            _gameOverPoint.InitGameOverPoint(_level);
        }

        public void Pause(bool flag)
        {
            _level.Pause(flag);
        }
    }
}