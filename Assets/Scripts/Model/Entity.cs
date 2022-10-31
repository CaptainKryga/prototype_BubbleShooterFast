using Model.Level;
using UnityEngine;

namespace Model
{
    public abstract class Entity : MonoBehaviour
    {
        protected LevelBase LevelBase;
        private SpriteRenderer _spriteRenderer;
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
        
        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _color = _spriteRenderer.color;
        }

        public abstract void Init(LevelBase levelBase);
        protected abstract void OnDestroy();
    }
}