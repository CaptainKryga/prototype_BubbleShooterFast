using Model.Static;
using UnityEngine;

namespace Model
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private SpriteRenderer sr;

        public Rigidbody2D RigidBody { get => rb; }
        private Color _color;
        
        public Color Color
        {
            get => _color;
            set
            {
                _color = value;
                sr.color = _color;
            }
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            // Debug.Log("collision");
            Border border = other.GetComponent<Border>();
            if (border)
            {
                Vector2 vel = rb.velocity;
                rb.velocity = new Vector2(border.IsX ? vel.x * -1 : vel.x, !border.IsX ? vel.y * -1 : vel.y);
                return;
            }
            Circle circle = other.GetComponent<Circle>();
            if (circle)
            {
                if (circle.Color == sr.color)
                {
                    Destroy(circle.gameObject);
                    Destroy(gameObject);
                }
                else
                {
                    rb.velocity = Vector2.zero;
                    Circle temp = gameObject.AddComponent<Circle>();
                    transform.position = GameMetrics.GetNearPoint(transform.position,
                        circle.transform.position);
                    temp.Nears = new Circle[6];
                    SetupNeighbors(temp);
                    temp.IsStatic = true;
                    
                    Destroy(rb);
                    Destroy(this);
                }
            }
        }

        private void SetupNeighbors(Circle circle)
        {
            //sphere raycast
            Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, 1f);
            Debug.Log(enemies.Length);
            foreach (var en in enemies)
            {
                Circle temp = en.GetComponent<Circle>();
                if (temp && temp.IsStatic)
                {
                    int index = GameMetrics.GetNeighborIndex(temp, circle);
                    temp.Nears[index] = circle;
                    index = GameMetrics.GetNeighborIndex(circle, temp);
                    circle.Nears[index] = temp;

                    if (temp.Color == _color)
                    {
                        Destroy(circle.gameObject);
                        Destroy(gameObject);
                    }
                }
                Debug.Log(en.name);
            }
        }
    }
}