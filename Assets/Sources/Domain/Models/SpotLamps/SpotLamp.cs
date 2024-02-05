using System;
using UnityEngine;

namespace Sources.Domain.Models.SpotLamps
{
    public class SpotLamp
    {
        private Vector2 _position;
        
        public event Action PositionChanged;

        public SpotLamp(Vector3 position)
        {
            Position = position;
        }
        
        public Vector2 Position
        {
            get => _position;
            set
            {
                _position = value;
                PositionChanged?.Invoke();
            }
        }

        public float Speed { get; set; } = 5f;
    }
}