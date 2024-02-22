using System.Reflection;
using Sources.Helps.Assets;
using Sources.MVVM.Presentations;
using Sources.MVVM.ViewModels;
using Binder = Sources.MVVM.Bindings.Binder;

namespace Sources.MVVM.Factories
{
    public class ViewFactory
    {
        private const string ConstructMethodName = "Construct";
        private const BindingFlags DefaultBindingFlags =  BindingFlags.Instance | BindingFlags.NonPublic;
        
        private readonly PrefabViewFactory _prefabViewFactory = new (new AssetProvider());
        private readonly Binder _binder = new ();

        public TView Create<TView, TViewModel>(TViewModel viewModel)
            where TView : View
            where TViewModel : IViewModel
        {
            var view = _prefabViewFactory.Create<TView>();

            var methodInfo = typeof(View).GetMethod(ConstructMethodName, DefaultBindingFlags);
            methodInfo?.Invoke(view, new object[]{viewModel, _binder});
            
            return view;
        }
    }
}