using Model.Components;
using Model.Level;
using UnityEngine;

namespace Model.Environment
{
    public class GameOverPoint : MonoBehaviour
    {
        private LevelBase _level;

        public void InitGameOverPoint(LevelBase level)
        {
            _level = level;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.GetComponent<Circle>())
            {
                _level.GameOver();
            }
        }
    }
}
