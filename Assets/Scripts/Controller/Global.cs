using Model;
using Model.Level;
using Scriptables;
using UnityEngine;

namespace Controller
{
    public class Global : MonoBehaviour
    {
        [SerializeField] private StarterLevelController starterLevelController;

        private LevelControllerBase _levelController;

        private void Start()
        {
            _levelController = starterLevelController.GetLevelController();
        }

        public void Pause(bool flag)
        {
            _levelController.Pause(flag);
        }
    }
}