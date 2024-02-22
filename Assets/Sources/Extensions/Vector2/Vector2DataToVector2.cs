using Sources.Domain;

namespace Sources.Extensions.Vector2
{
    public static partial class Vector2Extension
    {
        public static UnityEngine.Vector2 Vector2DataToVector2(this Vector2Data vector)
        {
            return new UnityEngine.Vector2(vector.X, vector.Y);
        }
    }
}