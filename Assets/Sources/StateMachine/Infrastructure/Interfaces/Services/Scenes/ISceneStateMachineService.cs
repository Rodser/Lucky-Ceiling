using Sources.StateMachine.Infrastructure.Interfaces.Services.Updates;

namespace Sources.StateMachine.Infrastructure.Interfaces.Services.Scenes
{
    public interface ISceneStateMachineService : ISceneChanger, IUpdatable
    {
    }
}