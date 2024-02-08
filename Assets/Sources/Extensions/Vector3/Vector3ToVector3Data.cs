using Sources.Domain;

namespace Sources.Extensions.Vector3
{
    public static partial class Vector3Extension
    {
        public static Vector3Data Vector3ToVector3Data(this UnityEngine.Vector3 vector)
        {
            return new Vector3Data {X = vector.x, Y = vector.y, Z = vector.z};
        }
    }
}