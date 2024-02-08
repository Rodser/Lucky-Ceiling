using Sources.Domain;

namespace Sources.Extensions.Vector3
{
    public static partial class Vector3Extension
    {
        public static UnityEngine.Vector3 Vector3DataToVector3(this Vector3Data vector)
        {
            return new UnityEngine.Vector3(vector.X, vector.Y, vector.Z);
        }
    }
}