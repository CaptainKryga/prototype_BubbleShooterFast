using System;
using Model.Level;
using UnityEngine;

namespace Model
{
    public class GameOverPoint : MonoBehaviour
    {
        [SerializeField] private LevelControllerBase _levelControllerBase;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.GetComponent<Circle>())
            {
                _levelControllerBase.GameOver();
            }
        }
    }
}
