using UnityEngine;

namespace Model.Gun
{
    public class GunRandom : GunBase
    {
        public override void Init(int[] queue)
        {
            GenNewBullet();
        }

        protected override void GenNewBullet()
        {
            Bullet = Instantiate(Prefab, Parent.position, Quaternion.identity, Parent);
            Bullet.Init(LevelController);
            Bullet.Color = DataGame.Colors[Random.Range(0, DataGame.Colors.Length)];
        }
    }
}