namespace Sources.MVVM.ViewModels
{
    public abstract class ViewModel<T> : IViewModel
    {
        protected ViewModel(T model)
        {
            Model = model;
        }

        protected T Model { get; }
        
        public abstract void Enable();

        public abstract void Disable();
    }
}