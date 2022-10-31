using Model.Components;
using UnityEngine;

namespace Model.Static
{
    public static class GameMetrics
    {
        public static int SizeMapX = 13;
        public static int SizeMapY = 29;

        public static float KoofHeightY = .8f;
        public static float KoofWeightX = .5f;

        private static readonly Vector2[] Neighbors =
        {
            new Vector2(-1,0),
            new Vector2(-.5f, -KoofHeightY),
            new Vector2(.5f, -KoofHeightY),
            new Vector2(1,0),
            new Vector2(.5f, KoofHeightY),
            new Vector2(-.5f, KoofHeightY)
        };

        public static Vector3 GetNeighborPoint(Vector2 pointBull, Vector2 pointCircle)
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
        
        public static void SyncNeighbors(int y, int x, Circle[][] map)
        {
            map[y][x].Neighbors = new Circle[6];
            
            //West
            if (x - 1 >= 0)
            {
                map[y][x].Neighbors[0] = map[y][x - 1];
            }
            //East
            if (x + 1 < SizeMapX)
            {
                map[y][x].Neighbors[3] = map[y][x + 1];
            }
            //Shift left
            if (y % 2 == 0)
            {
                if (y - 1 >= 0)
                {
                    //South-West
                    map[y][x].Neighbors[1] = map[y - 1][x];

                    //South-East
                    if (x - 1 >= 0)
                    {
                        map[y][x].Neighbors[2] = map[y - 1][x - 1];
                    }
                }

                if (y + 1 < SizeMapY)
                {
                    //North-West
                    map[y][x].Neighbors[4] = map[y + 1][x];

                    //North-East
                    if (x - 1 >= 0)
                    {
                        map[y][x].Neighbors[5] = map[y + 1][x - 1];
                    }
                }
            }
            //Don't shift
            else
            {
                if (y - 1 >= 0)
                {
                    //South-West
                    map[y][x].Neighbors[2] = map[y - 1][x];

                    //South-East
                    if (x + 1 < SizeMapX)
                    {
                        map[y][x].Neighbors[1] = map[y - 1][x + 1];
                    }
                }

                if (y + 1 < SizeMapY)
                {
                    //North-West
                    map[y][x].Neighbors[5] = map[y + 1][x];

                    //North-East
                    if (x + 1 < SizeMapX)
                    {
                        map[y][x].Neighbors[4] = map[y + 1][x + 1];
                    }
                }
            }
        }
    }
}