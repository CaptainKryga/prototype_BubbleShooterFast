using UnityEngine;

namespace Scriptables
{
    [CreateAssetMenu(fileName = "GameData", menuName = "ScriptableObjects/GameData", order = 1)]
    public class DataGame : ScriptableObject
    {
        public Color[] Colors;
        public Color ColorDisable;

        public int GetIdColor(Color color)
        {
            for (int x = 0; x < Colors.Length; x++)
            {
                if (Colors[x] == color)
                    return x;
            }

            return 9;
        }
    }
}