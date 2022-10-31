using Model.Level;
using Scriptables;
using UnityEngine;

namespace Model.Static
{
    public static class GenerateMap
    {
        public static void GenerateMapFromString(LevelBase level, DataGame dataGame, 
            Transform startInstance, Circle prefab, string import)
        {
            Circle[][] map = new Circle[GameMetrics.SizeMapY][];

            string[] parse = import.Split('#');
            for (int y = 0; y < parse.Length; y++)
            {
                map[y] = new Circle[GameMetrics.SizeMapX];
                for (int x = 0; x < parse[y].Length; x++)
                {
                    int num = parse[y][x] - '0';
                    if (num < 0 || num >= dataGame.Colors.Length)
                        continue;

                    map[y][x] = Object.Instantiate(prefab, startInstance.position + new Vector3(
                            y % 2 != 0 ? x + GameMetrics.KoofWeightX : x,
                            y * GameMetrics.KoofHeightY),
                        Quaternion.identity, startInstance);
                    
                    map[y][x].Color = dataGame.Colors[num];
                    map[y][x].name = "circle[" + x + "][" + y + "]";
                    map[y][x].IsStatic = true;
                    
                    map[y][x].Init(level);
                }
            }
            
            SyncNeighbors(map);
        }

        public static void GenerateMapFromRandom(LevelBase level, DataGame dataGame, 
            Transform startInstance, Circle prefab)
        {
            Circle[][] map = new Circle[GameMetrics.SizeMapY][];

            for (int y = 0; y < map.Length; y++)
            {
                map[y] = new Circle[GameMetrics.SizeMapX];
                for (int x = 0; x < map[y].Length; x++)
                {
                    if (Random.Range(0, 100) < 20)
                        continue;

                    map[y][x] = Object.Instantiate(prefab, startInstance.position + new Vector3(
                            y % 2 != 0 ? x + GameMetrics.KoofWeightX : x,
                            y * GameMetrics.KoofHeightY),
                        Quaternion.identity, startInstance);
                    
                    map[y][x].Color = dataGame.Colors[Random.Range(0, dataGame.Colors.Length)];
                    map[y][x].name = "circle[" + x + "][" + y + "]";
                    map[y][x].IsStatic = true;
                    
                    map[y][x].Init(level);
                }
            }

            SyncNeighbors(map);
        }

        private static void SyncNeighbors(Circle[][] map)
        {
            for (int y = 0; y < map.Length; y++)
            {
                for (int x = 0; x < map[y].Length; x++)
                {
                    if (map[y][x])
                        GameMetrics.SyncNeighbors(y, x, map);
                }
            }
        }
    }
}