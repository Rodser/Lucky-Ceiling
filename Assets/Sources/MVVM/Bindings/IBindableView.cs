namespace Sources.MVVM.Bindings
{
    public interface IBindableView
    {
        object OnBind();
    }
    
    public interface IBindableView<T> : IBindableView
    {
        ObservableProperty<T> OnBind();

        object IBindableView.OnBind()
        {
            return OnBind();
        }
    }
}