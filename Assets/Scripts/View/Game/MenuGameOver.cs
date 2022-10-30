using Model.Level;
using UnityEngine;

namespace View.Game
{
    public class MenuGameOver : MenuGameBase
    {
        [SerializeField] private LevelControllerBase _levelControllerBase;

        [SerializeField] private TMPro.TMP_Text _textWin;
        [SerializeField] private TMPro.TMP_Text _textScore;
        
        public LevelControllerBase LevelControllerBase { 
            get => _levelControllerBase;
            set => _levelControllerBase = value;
        }

        public void Init(LevelControllerBase levelControllerBase)
        {
            _levelControllerBase = levelControllerBase;
        }
        
        public override void UsePanel()
        {
            _textWin.text = _levelControllerBase.IsWin ? "WINNER" : "DEFEAT";
            _textScore.text = "Score: " + _levelControllerBase.Score;
            
            SetEnable(true);
        }
    }
}