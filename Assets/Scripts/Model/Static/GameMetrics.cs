using Unity.VisualScripting;
using UnityEngine;

namespace Model.Static
{
    public static class GameMetrics
    {
        public static int SizeMapX = 13;
        public static int SizeMapY = 29;

        public static float KoofHeightY = .8f;
        public static float KoofWeightX = .5f;

        public static Vector3 GetNearPoint(Vector2 pointBull, Vector2 pointCircle)
        {
            Vector2 save = Vector2.zero;
            float dist = Vector3.Distance(pointBull, pointCircle);
            for (float y = -KoofHeightY; y <= KoofHeightY; y += KoofHeightY)
            {
                for (float x = -KoofWeightX; x <= KoofWeightX; x += KoofWeightX)
                {
                    Vector2 newVec = new Vector2(x, y);
                    float distance = Vector3.Distance(pointBull, pointCircle + newVec);

                    if (distance < dist)
                    {
                        save = newVec;
                        dist = distance;
                    }
                }
            }

            return save + pointCircle;
        }
    }
}