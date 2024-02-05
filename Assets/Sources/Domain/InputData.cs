using UnityEngine;

namespace Sources.Domain
{
    public struct InputData
    {
        public Vector2 Direction { get; }
        public bool IsFire { get; }

        public InputData(Vector2 direction, bool isFire)
        {
            Direction = direction;
            IsFire = isFire;
        }
    }
}