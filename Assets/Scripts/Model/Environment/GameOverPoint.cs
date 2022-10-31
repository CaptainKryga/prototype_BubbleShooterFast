using Model.Level;
using UnityEngine;

namespace Model.Environment
{
    public class GameOverPoint : MonoBehaviour
    {
        private LevelControllerBase _levelController;

        public void InitGameOverPoint(LevelControllerBase levelController)
        {
            _levelController = levelController;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.GetComponent<Circle>())
            {
                _levelController.GameOver();
            }
        }
    }
}
