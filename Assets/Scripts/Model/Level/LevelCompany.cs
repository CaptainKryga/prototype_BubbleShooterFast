using Model.Static;

namespace Model.Level
{
    public class LevelCompany : LevelControllerBase
    {
        public override void InitLevel(int levelId)
        {
            Stats.IsWin = false;
            _isPlay = true;
            GenerateMap.GenerateMapFromString(this, DataGame, Parent, Prefab, 
                DataGame.DataCompany.Levels[levelId].Level);
            GunController.Init(DataGame.DataCompany.Levels[levelId].Queue);
        }
    }
}