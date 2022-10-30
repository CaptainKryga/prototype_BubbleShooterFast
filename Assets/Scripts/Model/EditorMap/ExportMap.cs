using Controller;
using Scriptables;
using UnityEngine;

namespace Model.EditorMap
{
    public class ExportMap : MonoBehaviour
    {
        [SerializeField] private DataGame _dataGame;
        
        [SerializeField] private CustomInput _customInput;
        [SerializeField] private GenerateMap _generateMap;

        [SerializeField] private string _export;
        
        private void OnEnable()
        {
            _customInput.InputKeyCode_Action += Export;
        }

        private void OnDisable()
        {
            _customInput.InputKeyCode_Action -= Export;
        }

        private void Export(KeyCode key, bool flag)
        {
            if (key != KeyCode.G)
                return;

            SpriteRenderer[][] map = _generateMap.Map;
            _export = "";

            for (int y = 0; y < map.Length; y++)
            {
                for (int x = 0; x < map[y].Length; x++)
                {
                    if (y % 2 != 0 && x + 1 == map[y].Length)
                        continue;
                    _export += _dataGame.GetIdColor(map[y][x].color);
                }
                
                if (y + 1 < map.Length)
                    _export += '#';
            }
        }
    }
}
