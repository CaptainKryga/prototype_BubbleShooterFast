using System;
using UnityEngine;

namespace Model
{
    public class Circle : MonoBehaviour
    {
        private SpriteRenderer _spriteRenderer;
        private Color _color;

        public Circle[] Nears;
        
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
        }

        public void Init(Color color)
        {
            _color = color;
        }

        public bool isTest;
        private void Update()
        {
            if (isTest)
            {
                isTest = false;
                for (int x = 0; x < Nears.Length; x++)
                    if (Nears[x])
                        Nears[x].Color = Color.white;
            }
        }
    }
}
