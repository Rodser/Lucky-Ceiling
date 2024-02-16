using System;
using UnityEngine;

namespace Sources.Domain.Models.SpotLamps
{
    public class SpotLamp
    {
        private Vector3 _position;
        
        public event Action PositionChanged;

        public SpotLamp(Vector3 position)
        {
            Position = position;
        }
        
        public Vector3 Position
        {
            get => _position;
            set
            {
                _position = value;
                PositionChanged?.Invoke();
            }
        }
    }
}