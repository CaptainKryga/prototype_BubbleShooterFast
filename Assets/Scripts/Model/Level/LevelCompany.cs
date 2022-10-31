using Model.Static;

namespace Model.Level
{
    public class LevelCompany : LevelBase
    {
        protected override void InitLevel(int levelId)
        {
            Stats.IsWin = false;
            IsPlay = true;
            GenerateMap.GenerateMapFromString(this, DataGame, Parent, Prefab, 
                DataGame.DataCompany.Levels[levelId].Level);
            GunBase.Init(DataGame.DataCompany.Levels[levelId].Queue);
        }
    }
}