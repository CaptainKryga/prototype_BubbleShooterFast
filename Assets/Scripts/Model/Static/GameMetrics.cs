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
            new Vector2(-1,0),
            new Vector2(-.5f, -KoofHeightY),
            new Vector2(.5f, -KoofHeightY),
            new Vector2(1,0),
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
        
        public static void SyncNeighbors(int y, int x, Circle[][] map)
        {
            map[y][x].Nears = new Circle[6];
            
            //West
            if (x - 1 >= 0)
            {
                map[y][x].Nears[0] = map[y][x - 1];
            }
            //East
            if (x + 1 < GameMetrics.SizeMapX)
            {
                Debug.Log(map[y][x]);
                Debug.Log(map[y][x].Nears);
                Debug.Log(map[y][x].Nears[3]);
                Debug.Log(map[y][x + 1]);
                map[y][x].Nears[3] = map[y][x + 1];
            }
            //Shift left
            if (y % 2 == 0)
            {
                if (y - 1 >= 0)
                {
                    //South-West
                    map[y][x].Nears[1] = map[y - 1][x];

                    //South-East
                    if (x - 1 >= 0)
                    {
                        map[y][x].Nears[2] = map[y - 1][x - 1];
                    }
                }

                if (y + 1 < GameMetrics.SizeMapY)
                {
                    //North-West
                    map[y][x].Nears[4] = map[y + 1][x];

                    //North-East
                    if (x - 1 >= 0)
                    {
                        map[y][x].Nears[5] = map[y + 1][x - 1];
                    }
                }
            }
            //Don't shift
            else
            {
                if (y - 1 >= 0)
                {
                    //South-West
                    map[y][x].Nears[2] = map[y - 1][x];

                    //South-East
                    if (x + 1 < GameMetrics.SizeMapX)
                    {
                        map[y][x].Nears[1] = map[y - 1][x + 1];
                    }
                }

                if (y + 1 < GameMetrics.SizeMapY)
                {
                    //North-West
                    map[y][x].Nears[5] = map[y + 1][x];

                    //North-East
                    if (x + 1 < GameMetrics.SizeMapX)
                    {
                        map[y][x].Nears[4] = map[y + 1][x + 1];
                    }
                }
            }
        }
    }
}