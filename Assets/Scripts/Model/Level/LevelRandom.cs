using Model.Static;

namespace Model.Level
{
    public class LevelRandom : LevelControllerBase
    {
        public override void InitLevel(int levelId)
        {
            Stats.IsWin = false;
            _isPlay = true;
            GenerateMap.GenerateMapFromRandom(this, DataGame, Parent, Prefab);
            GunController.Init(null);
        }
    }
}