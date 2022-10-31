using Model.Static;
using Scriptables;
using UnityEngine;

namespace Model.EditorMap
{
    public class GenerateMap : MonoBehaviour
    {
        [SerializeField] private DataGame _dataGame;
        
        //parent and start point
        [SerializeField] private Transform _parent;
        [SerializeField] private Circle _prefab;

        private Circle[][] _map;

        public Circle[][] Map { get => _map; }
        
        private void Start()
        {
            _map = new Circle[GameMetrics.SizeMapY][];
            
            Vector3 startPos = _parent.transform.position;
            for (int y = 0; y < GameMetrics.SizeMapY; y++)
            {
                _map[y] = new Circle[GameMetrics.SizeMapX];
                for (int x = 0; x < GameMetrics.SizeMapX; x++)
                {
                    if (y % 2 != 0 && x + 1 == GameMetrics.SizeMapX)
                        continue;

                    Vector3 sp = startPos + new Vector3(
                        y % 2 != 0 ? x + GameMetrics.KoofWeightX : x,
                        y * GameMetrics.KoofHeightY);
                    
                    _map[y][x] = Instantiate(_prefab, sp, Quaternion.identity, _parent);
                    _map[y][x].Color = _dataGame.ColorDisable;
                }
            }
        }
    }
}
