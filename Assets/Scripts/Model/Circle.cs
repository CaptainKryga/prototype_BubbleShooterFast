using UnityEngine;

namespace Model
{
    public class Circle : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        private Color _color;
        
        public Color Color
        {
            get => _color;
            set
            {
                _color = value;
                _spriteRenderer.color = _color;
            }
        }
    }
}
