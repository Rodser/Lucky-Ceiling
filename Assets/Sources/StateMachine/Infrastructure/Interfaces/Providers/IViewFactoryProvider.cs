using Sources.MVVM.Presentations;
using Sources.StateMachine.Infrastructure.Interfaces.Factories;

namespace Sources.StateMachine.Infrastructure.Interfaces.Providers
{
    public interface IViewFactoryProvider
    {
        T Get<T>() where T : IFactory<IView>;
    }
}