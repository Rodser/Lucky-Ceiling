using Sources.Helps.Assets;
using UnityEngine;

namespace Sources.MVVM.Factories
{
    public class PrefabViewFactory
    {
        private readonly IAssetProvider _assetProvider;

        public PrefabViewFactory(IAssetProvider assetProvider )
        {
            _assetProvider = assetProvider;
        }
        
        public T Create<T>(string path = "") where T : Object
        {
            return Object.Instantiate(_assetProvider.Get<T>(path));
        }
    }
}