using System;
using UnityEngine;

namespace Sources.App.Domains
{
    public class ItemModel
    {
        private const float Speed = 0.005f;

        private Vector3 _position;
        private Vector3 _rotation;

        public event Action<Vector3> Moved;
        public event Action<Vector3> RotationChanged;

        public ItemModel(Vector3 position)
        {
            _position = position;
        }

        public Vector3 Position
        {
            get => _position;
            set
            {
                _position = value;
                Moved?.Invoke(_position);
            }
        }
        
        public Vector3 Rotation
        {
            get => _rotation;
            set
            {
                _rotation = value;
                RotationChanged?.Invoke(_rotation);
            }
        }

        public void Move()
        {
            Position += Vector3.up * Speed;
        }
        
        public void Rotate()
        {
            Rotation += new Vector3(1,1,1);
        }
    }
}