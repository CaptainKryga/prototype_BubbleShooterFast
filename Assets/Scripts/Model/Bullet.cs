using Model.Environment;
using Model.Level;
using Model.Static;
using UnityEngine;

namespace Model
{
    public class Bullet : Entity
    {
        [SerializeField] private Rigidbody2D rb;
        public Rigidbody2D RigidBody { get => rb; }
        
        public override void Init(LevelBase levelBase)
        {
            LevelBase = levelBase;
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            Border border = other.GetComponent<Border>();
            if (border)
            {
                Vector2 vel = rb.velocity;
                rb.velocity = new Vector2(border.IsX ? vel.x * -1 : vel.x, !border.IsX ? vel.y * -1 : vel.y);
                return;
            }
            
            Entity entity = other.GetComponent<Entity>();
            if (entity && (entity as Circle) != null)
            {
                //change parent from move field(DLC)
                transform.SetParent(entity.transform.parent);
                //set position
                transform.position = GameMetrics.GetNeighborPoint(transform.position,
                    entity.transform.position);
                    
                //setup circle
                Circle circle = gameObject.AddComponent<Circle>();
                circle.Init(LevelBase);
                SetupNeighbors(circle);
                circle.IsStatic = true;

                //remove physics and bullet status
                Destroy(rb);
                Destroy(this);
            }
        }

        private void SetupNeighbors(Circle circle)
        {
            //sphere raycast
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 1f);
            foreach (var coll in colliders)
            {
                Circle temp = coll.GetComponent<Circle>();
                if (temp && temp.IsStatic)
                {
                    //sync link's
                    int index = GameMetrics.GetNeighborIndex(temp, circle);
                    temp.Neighbors[index] = circle;
                    index = GameMetrics.GetNeighborIndex(circle, temp);
                    circle.Neighbors[index] = temp;

                    if (temp.Color == Color)
                    {
                        Destroy(circle.gameObject);
                        Destroy(gameObject);
                    }
                }
            }
        }
        
        protected override void OnDestroy()
        {
            
        }
    }
}