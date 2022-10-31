using Model.Gun;
using Model.Level;
using UnityEngine;

namespace Controller
{
    public class Global : MonoBehaviour
    {
        [SerializeField] private StarterLevelController _starterLevelController;
        [SerializeField] private StarterGunBase _starterGunBase;

        private LevelControllerBase _levelController;

        private void Awake()
        {
            _levelController = _starterLevelController.GetLevelController();
            _levelController.SyncGunBase(_starterGunBase.GetGunBase(_levelController));
        }

        public void Pause(bool flag)
        {
            _levelController.Pause(flag);
        }
    }
}