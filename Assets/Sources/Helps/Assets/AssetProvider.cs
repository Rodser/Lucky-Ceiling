using UnityEngine;

namespace Sources.Helps.Assets
{
    public class AssetProvider : IAssetProvider
    {
        public T Get<T>(string path) where T : Object
        {
            return Resources.Load<T>(path + typeof(T).Name);
        }
    }
}