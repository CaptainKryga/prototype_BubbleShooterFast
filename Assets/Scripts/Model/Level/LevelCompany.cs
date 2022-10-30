using System;
using Model.Static;
using Scriptables;
using UnityEngine;

namespace Model.Level
{
    public class LevelCompany : LevelControllerBase
    {
        [SerializeField] private DataCompany _dataCompany;
        [SerializeField] private DataGame _dataGame;

        [SerializeField] private Transform startInstance;
        [SerializeField] private SpriteRenderer prefab;
        public override void InitLevel(int levelId)
        {
            GenerateMapFromString(_dataCompany.Levels[levelId]);
        }

        private void GenerateMapFromString(string map)
        {
            string[] parse = map.Split('#');
            for (int y = 0; y < parse.Length; y++)
            {
                for (int x = 0; x < parse[y].Length; x++)
                {
                    int num = parse[y][x] - '0';
                    if (num < 1 || num > _dataGame.Colors.Length)
                        continue;

                    Instantiate(prefab, 
                        startInstance.position + new Vector3(y % 2 != 0 ? x + GameMetrics.KoofWeightX : x, y * GameMetrics.KoofHeightY),
                        Quaternion.identity, startInstance).color = _dataGame.Colors[num];
                }
            }
        }
    }
}