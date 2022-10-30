using UnityEngine;

namespace Scriptables
{
    [CreateAssetMenu(fileName = "GameData", menuName = "ScriptableObjects/GameData", order = 1)]
    public class GameData : ScriptableObject
    {
        public Color[] Colors;
        public Color ColorDisable;
    }
}