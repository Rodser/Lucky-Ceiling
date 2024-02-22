using Sources.Domain;

namespace Sources.Extensions.Vector2
{
    public static partial class Vector2Extension
    {
        public static Vector2Data Vector2ToVector2Data(this UnityEngine.Vector2 vector)
        {
            return new Vector2Data {X = vector.x, Y = vector.y};
        }
    }
}