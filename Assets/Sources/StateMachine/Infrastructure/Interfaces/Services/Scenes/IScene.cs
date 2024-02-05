using Sources.StateMachine.Infrastructure.Interfaces.StateMaсhines;

namespace Sources.StateMachine.Infrastructure.Interfaces.Services.Scenes
{
    public interface IScene : IState
    {
        string Name { get;}
    }
}