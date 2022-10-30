using System;
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
        
        public enum Nears
        {
            W, SW, SE, E, NE, NW
        }

        public static Vector2[] Neighbors =
        {
            new Vector2(-KoofWeightX,0),
            new Vector2(-.5f, -KoofHeightY),
            new Vector2(.5f, -KoofHeightY),
            new Vector2(KoofWeightX,0),
            new Vector2(.5f, KoofHeightY),
            new Vector2(-.5f, KoofHeightY)
        };

        public static Vector3 GetNearPoint(Vector2 pointBull, Vector2 pointCircle)
        {
            Vector2 save = Vector2.zero;
            float dist = Vector3.Distance(pointBull, pointCircle);
            for (int x = 0; x < Neighbors.Length; x++)
            {
                float distance = Vector3.Distance(pointBull, pointCircle + Neighbors[x]);

                if (distance < dist)
                {
                    save = Neighbors[x];
                    dist = distance;
                }
            }
            return save + pointCircle;
        }

        public static int GetNeighborIndex(Circle first, Circle second)
        {
            Vector2 vec = second.transform.position - first.transform.position;
            for (int x = 0; x < Neighbors.Length; x++)
            {
                if (Vector3.Distance(vec, Neighbors[x]) < 0.1f)
                    return x;
            }

            return 0;
        }
    }
}