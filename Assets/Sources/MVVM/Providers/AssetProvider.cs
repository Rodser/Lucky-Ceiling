using UnityEngine;

namespace Sources.MVVM.Providers
{
    public static class AssetProvider
    {
        public static T Get<T>(string path) where T : Object
        {
            return Resources.Load<T>(path + typeof(T).Name);
        }
    }
}