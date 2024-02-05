using Sources.StateMachine.Infrastructure.Interfaces.Providers;

namespace Sources.App.Infrastructure.Interfaces.Repositories
{
    public interface IStorable
    {
        void Load(IViewFactoryProvider viewFactoryProvider);
        void Save();
    }
}