using UnityEngine;

namespace Model.Gun
{
    public class GunCompany : GunBase
    {
        private int[] _queue;
        private int _colorId;
        
        public override void Init(int[] queue)
        {
            _queue = queue;
            GenNewBullet();
        }

        protected override void GenNewBullet()
        {
            Bullet = Instantiate(Prefab, Parent.position, Quaternion.identity, Parent);
            Bullet.Init(Level);
            Bullet.Color = DataGame.Colors[_queue[_colorId++]];
            if (_colorId >= _queue.Length) _colorId = 0;
        }
    }
}
