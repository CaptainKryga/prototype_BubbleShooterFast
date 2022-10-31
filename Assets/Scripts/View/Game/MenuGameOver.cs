using Model;
using UnityEngine;

namespace View.Game
{
    public class MenuGameOver : MenuGameBase
    {
        [SerializeField] private Stats _stats;

        [SerializeField] private TMPro.TMP_Text _textWin;
        [SerializeField] private TMPro.TMP_Text _textScore;

        public override void UsePanel()
        {
            _textWin.text = _stats.IsWin ? "WINNER" : "DEFEAT";
            _textScore.text = "Score: " + _stats.Score;
            
            SetEnable(true);
        }
    }
}