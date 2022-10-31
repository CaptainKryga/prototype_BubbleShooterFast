using Model.Static;
using Scriptables;
using UnityEngine;
using View.Game;

namespace Model.Level
{
    public class LevelCompany : LevelControllerBase
    {
        [SerializeField] private DataCompany _dataCompany;
        [SerializeField] private DataGame _dataGame;

        [SerializeField] private GunController _gunController;
        [SerializeField] private MenuGameBase _menuGameOver;
        
        [SerializeField] private Transform startInstance;
        [SerializeField] private Circle prefab;

        private Circle[][] _map;
        public override void InitLevel(int levelId)
        {
            GenerateMapFromString(_dataCompany.Levels[levelId].Level);
            _gunController.Init(_dataCompany.Levels[levelId].Queue);
        }

        public override void GameOver()
        {
            _menuGameOver.UsePanel();
        }

        private void GenerateMapFromString(string map)
        {
            _map = new Circle[GameMetrics.SizeMapY][];

            string[] parse = map.Split('#');
            for (int y = 0; y < parse.Length; y++)
            {
                _map[y] = new Circle[GameMetrics.SizeMapX];
                for (int x = 0; x < parse[y].Length; x++)
                {
                    int num = parse[y][x] - '0';
                    if (num < 0 || num >= _dataGame.Colors.Length)
                        continue;

                    _map[y][x] = Instantiate(prefab, startInstance.position + new Vector3(
                            y % 2 != 0 ? x + GameMetrics.KoofWeightX : x,
                            y * GameMetrics.KoofHeightY),
                        Quaternion.identity, startInstance);
                    
                    _map[y][x].Color = _dataGame.Colors[num];
                    _map[y][x].name = "coord: " + x + " " + y;
                    _map[y][x].IsStatic = true;
                    
                    _map[y][x].Init(this);
                }
            }
            
            for (int y = 0; y < parse.Length; y++)
            {
                for (int x = 0; x < parse[y].Length; x++)
                {
                    if (_map[y][x])
                        SetNears(y, x, _map);
                }
            }
        }

        private void SetNears(int y, int x, Circle[][] map)
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