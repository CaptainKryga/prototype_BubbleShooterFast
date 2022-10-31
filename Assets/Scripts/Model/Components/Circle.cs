using Model.Level;

namespace Model.Components
{
    public class Circle : Entity
    {
        public Circle[] Neighbors;
        public bool IsStatic;
        
        public override void Init(LevelBase levelBase)
        {
            LevelBase = levelBase;
            levelBase.CountCircles++;

            Neighbors = new Circle[6];
        }

        protected override void OnDestroy()
        {
            foreach (var near in Neighbors)
            {
                if (near && near.Color == base.Color)
                    Destroy(near.gameObject);
            }

            LevelBase.CountCircles--;
        }
    }
}
