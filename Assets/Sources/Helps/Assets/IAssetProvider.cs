using UnityEngine;

namespace Sources.Helps.Assets
{
    public interface IAssetProvider
    {
        T Get<T>(string path) where T : Object;
    }
}