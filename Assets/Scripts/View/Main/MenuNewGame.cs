using UnityEngine;

namespace View.Main
{
    public class MenuNewGame : MenuMainBase
    {
        [SerializeField] private MenuMainBase _company;
        [SerializeField] private MenuMainBase _random;
        
        public void OnClick_Company()
        {
            _company.UsePanel(PanelBase);
            SetEnable(false);
        }

        public void OnClick_Random()
        {
            _random.UsePanel(PanelBase);
            SetEnable(false);
        }
    }
}