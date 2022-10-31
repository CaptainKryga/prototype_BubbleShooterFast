﻿using Model.Static;

namespace Model.Level
{
    public class LevelRandom : LevelControllerBase
    {
        protected override void InitLevel(int levelId)
        {
            Stats.IsWin = false;
            IsPlay = true;
            GenerateMap.GenerateMapFromRandom(this, DataGame, Parent, Prefab);
            GunBase.Init(null);
        }
    }
}