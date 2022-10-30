namespace View.Game
{
    public class MenuPause : MenuGameBase
    {
        public override void UsePanel()
        {
            SetEnable(true);
        }

        public void OnClick_Continue()
        {
            SetEnable(false);
        }
    }
}