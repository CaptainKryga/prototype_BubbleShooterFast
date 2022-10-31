using Controller;
using UnityEngine;

namespace View.Game
{
    public class MenuPause : MenuGameBase
    {
        [SerializeField] private Global _global;

        public override void UsePanel()
        {
            SetEnable(true);
        }

        public void OnClick_SetPause()
        {
            PanelBase.SetActive(!PanelBase.activeSelf);
            _global.Pause(PanelBase.activeSelf);
        }
    }
}