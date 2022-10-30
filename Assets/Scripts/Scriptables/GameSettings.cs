using UnityEngine;

namespace Scriptables
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "ScriptableObjects/GameSettings", order = 1)]
    public class GameSettings : ScriptableObject
    {
        public bool IsCompany;
        public int LevelId;
    }
}