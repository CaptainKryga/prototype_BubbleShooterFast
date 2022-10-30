using Model.Static;
using Scriptables;
using UnityEngine;

namespace Model.EditorMap
{
    public class GenerateMap : MonoBehaviour
    {
        [SerializeField] private DataGame _dataGame;
        
        //parent and start point
        [SerializeField] private Transform parent;
        [SerializeField] private SpriteRenderer prefab;

        private SpriteRenderer[][] _map;

        public SpriteRenderer[][] Map { get => _map; }
        
        private void Start()
        {
            _map = new SpriteRenderer[GameMetrics.SizeMapY][];
            
            Vector3 startPos = parent.transform.position;
            for (int y = 0; y < GameMetrics.SizeMapY; y++)
            {
                _map[y] = new SpriteRenderer[GameMetrics.SizeMapX];
                for (int x = 0; x < GameMetrics.SizeMapX; x++)
                {
                    if (y % 2 != 0 && x + 1 == GameMetrics.SizeMapX)
                        continue;

                    Vector3 sp = startPos + new Vector3(
                        y % 2 != 0 ? x + GameMetrics.KoofWeightX : x,
                        y * GameMetrics.KoofHeightY);
                    
                    _map[y][x] = Instantiate(prefab, sp, Quaternion.identity, parent);
                    _map[y][x].color = _dataGame.ColorDisable;
                }
            }
        }
    }
}
