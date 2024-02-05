using Sources.MVVM.Providers;
using UnityEngine;

namespace Sources.MVVM.Factories
{
    public class PrefabViewFactory
    {
        public T Create<T>(string path = "") where T : Object
        {
            return Object.Instantiate(AssetProvider.Get<T>(path));
        }
    }
}